using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SistemaCadastroDeHorasApi.Models;

namespace SistemaCadastroDeHorasApi.Context;

public class DataContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tipo_Atividade> TiposAtividade { get; set; }
    public DbSet<Tipo_Participacao> TiposParticipacao { get; set; }
    public DbSet<Atividades> Atividades { get; set; }
    public DbSet<AtividadeUsuario> AtividadeUsuarios { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Tipo_Participacao>().HasData(
            new Tipo_Participacao { Id = 1, nome = Models.ENUMS.Tipo_ParticipacaoEnum.MEMBRO_DA_EQUIPE_DE_TRABALHO },
            new Tipo_Participacao { Id = 2, nome = Models.ENUMS.Tipo_ParticipacaoEnum.PUBLICO_ATENDIDO_OU_ESPECTADOR }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

}
