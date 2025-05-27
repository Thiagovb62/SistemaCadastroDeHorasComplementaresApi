using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace SistemaCadastroDeHorasApi.Models;

[Table("Atividades")]
[Index(nameof(Id), IsUnique = true)]
public class Atividade
{
    
    [Key]
    public Guid Id { get; set; }
    
    
}