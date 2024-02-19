using NewsCmsApiGateway.Extensions;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);
//Eureka
builder.Services.AddDiscoveryClient();
//Yarp
builder.Services.AddReverseProxy().LoadFromEureka();
//.LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.MapReverseProxy();
app.Run();
