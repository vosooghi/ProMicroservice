using Microsoft.EntityFrameworkCore;
using ObservabilitySamples.API02.Models;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

//OpenTelemetry
const string serviceName = "ObservabilitySamples.API02";
const string serviceVersion = "1.0.0";

builder.Services.AddOpenTelemetry()
      .ConfigureResource(resource =>
      resource.AddService(serviceName,serviceVersion))
      .WithTracing(tracing => tracing
          .AddAspNetCoreInstrumentation()
          .AddSqlClientInstrumentation()
          .AddHttpClientInstrumentation()
          .AddConsoleExporter().AddJaegerExporter());
      //.WithMetrics(metrics => metrics
      //    .AddAspNetCoreInstrumentation()
      //    .AddConsoleExporter());

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<PeopleContext>(c =>
c.UseSqlServer("server=.;initial catalog=PeopleDb;user id=sa;password=P@ssw0rd;encrypt=false"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
