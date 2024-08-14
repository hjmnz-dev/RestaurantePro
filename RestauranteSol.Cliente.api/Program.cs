using Microsoft.EntityFrameworkCore;
using RestaurantePro.Cliente.Persistance.Context;
using RestaurantePro.Cliente.IOC.Dependencies;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<RestauranteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestauranteContext")));

// Agregar las dependencias del Modulo de Factura
builder.Services.AddClienteDependency();

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

// Set culture to en-US



app.UseAuthorization();

app.MapControllers();

app.Run();
