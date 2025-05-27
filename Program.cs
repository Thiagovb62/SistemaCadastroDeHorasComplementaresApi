using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SistemaCadastroDeHorasApi.Context;
using SistemaCadastroDeHorasApi.Migrations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer(); ;
builder.Services.AddScoped<DataContext>();

Env.Load();
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");


var connectionStringBase = builder.Configuration.GetConnectionString("DefaultConnection");
var fullConnectionString = $"{connectionStringBase};Password={dbPassword}";

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(fullConnectionString));

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
    });
}

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1"); });
    app.ApplyMigrations();
}

app.Run();