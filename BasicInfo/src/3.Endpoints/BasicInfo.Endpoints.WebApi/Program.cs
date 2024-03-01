
/*using BasicInfo.Endpoints.WebApi.Extentions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().ConfigurePipeline();
app.Run();*/

using BasicInfo.Endpoints.WebApi.Extentions;
using Ground.Extensions.DependencyInjection;
using Ground.Utilities.SerilogRegistration.Extensions;

SerilogExtensions.RunWithSerilogExceptionHandling(() =>
{
    var builder = WebApplication.CreateBuilder(args);    
    var app = builder.AddGroundSerilog(c =>
    {
        c.ApplicationName = builder.Configuration["ApplicationName"];
        c.ServiceName = builder.Configuration["ServiceName"];
        c.ServiceVersion = builder.Configuration["ServiceVersion"];
        c.ServiceId = Guid.NewGuid().ToString();
    }).ConfigureServices().ConfigurePipeline();
    app.Run();
});
