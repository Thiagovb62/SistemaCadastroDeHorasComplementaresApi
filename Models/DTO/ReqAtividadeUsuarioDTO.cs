using System.ComponentModel.DataAnnotations;

namespace SistemaCadastroDeHorasApi.Models.DTO;

public record ReqAtividadeUsuarioDTO(
    [Required, StringLength(100, MinimumLength = 3)]
    string Nome,
    [Required, StringLength(100, MinimumLength = 3)]
    string Descricao,
    [Required,DataType(DataType.Date)]
    DateTime DataInicio,
    [Required,DataType(DataType.Date)]
    DateTime DataFim,
    [Required, Range(1, int.MaxValue)]
    int TipoAtividadeId,
    [Required, Range(1, int.MaxValue)]
    int TipoParticipacaoId,
    [Required, StringLength(100, MinimumLength = 3)]
    string pais,
    [Required, StringLength(100, MinimumLength = 3)]
    string titulo,
    [Required, StringLength(100, MinimumLength = 3)]
    string nomeInstituicao,
    [Required]
    bool isExecUfc,
    [Required, Range(1, int.MaxValue)]
    int cargaHoraria,
    [Required, Range(0, int.MaxValue)]
    int qtdHorasUtilizadas,
    
    string? cnpj = null
    
){}