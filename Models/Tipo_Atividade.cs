using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SistemaCadastroDeHorasApi.Models;

[Table("Tipo_Atividade")]
[Serializable]

public class Tipo_Atividade
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public int Id { get; set; }
    
    [Required]
    public ENUMS.Tipo_AtividadeEnum nome { get; set; }
    
}