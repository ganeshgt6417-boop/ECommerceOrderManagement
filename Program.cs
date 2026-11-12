using Microsoft.EntityFrameworkCore;
using ECommerceOrderManagement.API.Data;

using ECommerceOrderManagement.API.Repositories;
using ECommerceOrderManagement.API.Services;
using ECommerceOrderManagement.API.Middleware;


var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();
app.UseMiddleware<GlobalExceptionMiddleware>();

// Configure Swagger
app.UseSwagger();
app.UseSwaggerUI();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();