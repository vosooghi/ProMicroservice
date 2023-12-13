using DomainEventSamples.Core.ApplicationServices;
using DomainEventSamples.Core.ApplicationServices.People.EventHandlers;
using DomainEventSamples.Core.Events;
using DomainEventSamples.Framework;
using DomainEventSamples.Infra.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SampleContext>(c=>c.UseSqlServer("server=.;initial catalog=Person2Db;user id=sa;password= P@ssw0rd;encrypt=false"));

builder.Services.AddScoped<PersonService>();
builder.Services.AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
//register domain event handlers
builder.Services.AddTransient<IDomainEventHandler<PersonCreated>, WritePersonCreatedToConsole>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
