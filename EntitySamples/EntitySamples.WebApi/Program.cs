using EntitySamples.IdGenerators.Contract;
using EntitySamples.IdGenerators.SnowFlake;
using EntitySamples.IdGenerators.SqlSequence;
using EntitySamples.IdGenerators.StaticClass;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<IIdGenerator, StaticIdGenerator>();
//builder.Services.AddSingleton<IIdGenerator, SqlSequenceIdGenerator>();
builder.Services.AddSingleton<IIdGenerator, SnowFlakeIdGenerator>();

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
