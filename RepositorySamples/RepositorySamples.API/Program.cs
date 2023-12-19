using Microsoft.EntityFrameworkCore;
using RepositorySamples.DAL;
using RepositorySamples.DAL.Categories;
using RepositorySamples.DAL.Common;
using RepositorySamples.DAL.Products;
using RepositorySamples.Domain.Categories;
using RepositorySamples.Domain.Common;
using RepositorySamples.Domain.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RepoSampleDbContext>(w => w.UseSqlServer("Server=.;initial catalog=RepoSample;user id = sa;password=P@ssw0rd;encrypt=false"));
builder.Services.AddScoped<IRepositorySampleDomainUnitOfWork, EfRepositorySampleDomainUnitOfWork>();
builder.Services.AddScoped<IProductRepository,EfProductRepository>();
builder.Services.AddScoped<ICategoryRepository,EfCategoryRepository>();

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
