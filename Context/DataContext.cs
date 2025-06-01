using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SistemaCadastroDeHorasApi.Models;

namespace SistemaCadastroDeHorasApi.Context;

public class DataContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tipo_Atividade> TiposAtividade { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

}
