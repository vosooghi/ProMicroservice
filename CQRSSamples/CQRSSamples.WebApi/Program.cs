using CQRSSamples.Domain.Categories;
using CQRSSamples.Domain.Common;
using CQRSSamples.Domain.Products;
using Microsoft.EntityFrameworkCore;
using CQRSSamples.ApplicationService.Categories;
using CQRSSamples.ApplicationService.Products;
using CQRSSamples.ApplicationService.Categories.Commands.CreateCategories;
using CQRSSamples.ApplicationService.Categories.Commands.UpdateCategories;
using CQRSSamples.ApplicationService.Products.Commands.CreateProducts;
using CQRSSamples.Command.DAL.Common;
using CQRSSamples.Command.DAL;
using CQRSSamples.Command.DAL.Categories;
using CQRSSamples.Command.DAL.Products;
using CQRSSamples.Queries.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RepoSampleCommandDbContext>(w => w.UseSqlServer("Server=.;initial catalog=CQRSSample;user id = sa;password=P@ssw0rd;encrypt=false"));
builder.Services.AddDbContext<RepoSampleQueryDbContext>(w => w.UseSqlServer("Server=.;initial catalog=CQRSSample;user id = sa;password=P@ssw0rd;encrypt=false"));
builder.Services.AddScoped<IRepositorySampleDomainUnitOfWork, EfRepositorySampleDomainUnitOfWork>();
builder.Services.AddScoped<IProductRepository, EfProductRepository>();
builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
//builder.Services.AddScoped<CategoryServices>();
//builder.Services.AddScoped<ProductService>();

builder.Services.AddScoped<CreateCategoryHandler>();
builder.Services.AddScoped<UpdateCategoryHandler>();
builder.Services.AddScoped<CreateProductHandler>();
builder.Services.AddScoped<CreateProductHandler>();

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
