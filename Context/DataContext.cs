using Microsoft.EntityFrameworkCore;
using SistemaCadastroDeHorasApi.Models;

namespace SistemaCadastroDeHorasApi.Context;

public class DataContext : DbContext
{
    public DbSet<Atividade> Atividades { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
}
