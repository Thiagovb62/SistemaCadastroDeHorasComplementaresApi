using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using SistemaCadastroDeHorasApi.Models;

namespace SistemaCadastroDeHorasApi.Context;

public class DataContext : DbContext
{
    
    public DbSet<Atividade> Atividades { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
            
    }
    
}