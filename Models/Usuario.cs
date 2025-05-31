using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCadastroDeHorasApi.Models;

public class Usuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incremento
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A matrícula é obrigatória")]
    public string Matricula { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "A role é obrigatória")]
    public string Role { get; set; }

    [Required(ErrorMessage = "O semestre de ingresso é obrigatório")]
    public int SemestreDeIngresso { get; set; }
}