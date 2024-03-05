using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//OpenTelemetry
const string serviceName = "ObservabilitySamples.API01";
const string serviceVersion = "1.0.0";
builder.Services.AddOpenTelemetry()
      .ConfigureResource(resource =>
      resource.AddService(serviceName, serviceVersion))
      .WithTracing(tracing => tracing
          .AddAspNetCoreInstrumentation()
          .AddSqlClientInstrumentation()
          .AddHttpClientInstrumentation()
          .AddConsoleExporter().AddJaegerExporter());

builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("Person", c =>
{
    c.BaseAddress = new Uri("http://localhost:5142");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
