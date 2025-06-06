using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCadastroDeHorasApi.Models;

[Table("Tipo_Participacao")]
[Serializable]
public class Tipo_Participacao
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public int Id { get; set; }

    [Required]
    public ENUMS.Tipo_ParticipacaoEnum nome { get; set; }
}

