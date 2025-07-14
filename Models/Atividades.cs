using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SistemaCadastroDeHorasApi.Models.ENUMS;


namespace SistemaCadastroDeHorasApi.Models;

[Table("Atividades")]
[Serializable]
public class Atividades
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [ForeignKey("TipoAtividadeId")]
    public int TipoAtividadeId { get; set; }

    [Required] public Tipo_Atividade TipoAtividade { get; set; }

    [Required]
    [ForeignKey(nameof(Usuario))]
    public int UsuarioId { get; set; }

    [Required] public Usuario usuario { get; set; }

    [Required]
    [ForeignKey("TipoParticipacaoId")]
    public int TipoParticipacaoId { get; set; }

    [Required] public Tipo_Participacao TipoParticipacao { get; set; }

    [Required][StringLength(100)] public string pais { get; set; }

    [Required][StringLength(100)] public string titulo { get; set; }

    [Required][StringLength(100)] public string nomeInstituicao { get; set; }

    [StringLength(100)] public string? cnpj { get; set; }

    [Required] public DateTime dataInicio { get; set; }

    [Required] public DateTime dataFim { get; set; }

    [Required] public bool isExecUfc { get; set; }

    [Required] public int cargaHoraria { get; set; }

    [Required] public int qtdHorasUtilizadas { get; set; }

    [Required][Column(TypeName = "bytea")][JsonIgnore] public byte[] comprovante { get; set; }

    [Required][StringLength(100)] public string nomeArquivo { get; set; }

    [Required][StringLength(50)] public string tipoArquivo { get; set; }
    
    public CategoriaAtividadeComplementarEnum categoriaAtividadeComplementarHoras { get; set; }
    
}