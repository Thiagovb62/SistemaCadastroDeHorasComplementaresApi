using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SistemaCadastroDeHorasApi.Context;
using SistemaCadastroDeHorasApi.Exception;
using SistemaCadastroDeHorasApi.Migrations;
using SistemaCadastroDeHorasApi.Repositories;
using SistemaCadastroDeHorasApi.Repositories.Contracts;
using SistemaCadastroDeHorasApi.Services;
using SistemaCadastroDeHorasApi.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

Env.Load();

var host = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost";
var user = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "postgres";
var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "";
var database = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? "osbbd";

var connectionString = $"Host={host};Port=5432;Database={database};Username={user};Password={password}";
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ITipo_AtividadeService, Tipo_AtividadeService>();
builder.Services.AddScoped<ITipo_AtividadeRepository, Tipo_AtividadeRepository>();
builder.Services.AddScoped<ITipo_ParticipacaoService, Tipo_ParticipacaoService>();
builder.Services.AddScoped<ITipo_ParticipacaoRepository, Tipo_ParticipacaoRepository>();
builder.Services.AddScoped<IAtividadesRepository, AtividadesRepository>();
builder.Services.AddScoped<IAtividadeUsuarioRepository, AtividadeUsuarioRepository>();
builder.Services.AddScoped<IAtividadeUsuarioService, AtividadeUsuarioService>();
builder.Services.AddScoped<IComprovanteService, ComprovanteService>();

builder.Services.AddControllers();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo { Title = "Sistema Cadastro de Horas", Description = "API para cadastro de horas", Version = "v1" });
    });
}

var app = builder.Build();
app.UseMiddleware<ErrorHandlerMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema Cadastro de Horas V1");
        c.RoutePrefix = string.Empty; // Ajuste conforme necessário
    });
    app.ApplyMigrations();
}


app.MapControllers();

app.Run();
