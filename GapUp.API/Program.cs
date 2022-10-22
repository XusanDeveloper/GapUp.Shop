using GapUp.Data.Contracts;
using GapUp.Data.Repositories;
using GapUp.Domain.Contexts;
using GapUp.Services.Extensions;
using GapUp.Services.Interfaces;
using GapUp.Services.Services;
using Microsoft.EntityFrameworkCore;
using NLog;

var builder = WebApplication.CreateBuilder(args);


LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILoggerManager, LoggerManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.ConfigureRepositoryManager();

builder.Services.AddDbContext<GapUpDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GapUpDb")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
