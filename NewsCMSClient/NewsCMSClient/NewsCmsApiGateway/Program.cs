using NewsCmsApiGateway.Extensions;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);
//Eureka
builder.Services.AddDiscoveryClient();
//Yarp
builder.Services.AddReverseProxy().LoadFromEureka();
//.LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("health/status");
});


app.MapReverseProxy();
app.Run();
