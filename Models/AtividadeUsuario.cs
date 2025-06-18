using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SistemaCadastroDeHorasApi.Models.ENUMS;

namespace SistemaCadastroDeHorasApi.Models;

public class AtividadeUsuario
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey(nameof(Usuario))]
    [Required]
    public int UsuarioId { get; set; }
    [Required]
    public Usuario Usuario { get; set; }
    [ForeignKey(nameof(Atividade))]
    public Guid AtividadeId { get; set; }
    [Required]
    public Atividades Atividade { get; set; }
    
    public StatusAtividadeEnum Status { get; set; }
}