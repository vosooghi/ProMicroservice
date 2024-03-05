using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;

namespace IdentityServer;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        //OpenTelemetry
        const string serviceName = "NewsCMS.IdentityServer";
        const string serviceVersion = "1.0.0";

        builder.Services.AddOpenTelemetry()
              .ConfigureResource(resource =>
              resource.AddService(serviceName, serviceVersion))
              .WithTracing(tracing => tracing
                  .AddAspNetCoreInstrumentation()
                  .AddSqlClientInstrumentation()
                  .AddHttpClientInstrumentation()
                  .AddConsoleExporter().AddJaegerExporter());

        // uncomment if you want to add a UI
        builder.Services.AddRazorPages();

        builder.Services.AddIdentityServer(options =>
            {
                // https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/api_scopes#authorization-based-on-scopes
                options.EmitStaticAudienceClaim = true;
            })            
            .AddInMemoryIdentityResources(Config.IdentityResources)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddInMemoryClients(Config.Clients)
            .AddTestUsers(TestUsers.Users);

        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    { 
        app.UseSerilogRequestLogging();
    
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // uncomment if you want to add a UI
        app.UseStaticFiles();
        app.UseRouting();

        app.UseIdentityServer();

        // uncomment if you want to add a UI
        app.UseAuthorization();
        app.MapRazorPages().RequireAuthorization();

        return app;
    }
}
