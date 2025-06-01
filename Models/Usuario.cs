using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCadastroDeHorasApi.Models;

public class Usuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incremento
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Matricula { get; set; }

    [Required]
    public string Senha { get; set; }
    
    public string Role { get; set; }

    [Required]
    public int SemestreDeIngresso { get; set; }
}