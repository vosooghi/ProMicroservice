using NewsCmsApiGateway.Extensions;
using Steeltoe.Discovery.Client;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.Elasticsearch;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();
Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    //Serilog
    builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.MSSqlServer(
        connectionString: "Server=.;Database=LogDb;User Id=sa; Password=P@ssw0rd;encrypt=false",
        sinkOptions: new MSSqlServerSinkOptions { TableName = "LogEvents", AutoCreateSqlTable = true, AutoCreateSqlDatabase = true })
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
    {
        AutoRegisterTemplate = true,
        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
        IndexFormat = "mynewscms-client-index-{0:yyyy.MM}",
        MinimumLogEventLevel = Serilog.Events.LogEventLevel.Debug,
    })
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(ctx.Configuration));


    //Eureka
    builder.Services.AddDiscoveryClient();
    //Yarp
    builder.Services.AddReverseProxy().LoadFromEureka();
    //.LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

    builder.Services.AddHealthChecks();

    var app = builder.Build();
    app.MapReverseProxy();
    app.UseRouting();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapHealthChecks("health/live");
    });


    
    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}