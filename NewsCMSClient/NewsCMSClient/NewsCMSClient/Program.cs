using Serilog;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.MSSqlServer;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateBootstrapLogger();
Log.Information("Starting up");

try
{

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
    .WriteTo.MSSqlServer(
        connectionString: "Server=.;Database=LogDb;User Id=sa; Password=P@ssw0rd;encrypt=false",
        sinkOptions: new MSSqlServerSinkOptions { TableName = "LogEvents", AutoCreateSqlTable = true, AutoCreateSqlDatabase = true })
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
    {
        AutoRegisterTemplate = true,
        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
        IndexFormat = "mynewscms-apigateway-index-{0:yyyy.MM}",
        MinimumLogEventLevel = Serilog.Events.LogEventLevel.Debug,
    })
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(ctx.Configuration));

    builder.Services.AddHttpClient("bi", c =>
    {
        c.BaseAddress = new Uri("http://localhost:8000/bi/");
    });//BasicInfo
    builder.Services.AddHttpClient("news", c =>
    {
        c.BaseAddress = new Uri("http://localhost:8000/news/");
    });//NewsCMS

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    //Health Check
    builder.Services.AddHealthChecks();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    //app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapHealthChecks("health/status");

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

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