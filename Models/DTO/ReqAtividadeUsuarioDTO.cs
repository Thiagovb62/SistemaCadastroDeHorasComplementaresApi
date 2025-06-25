using System.ComponentModel.DataAnnotations;

namespace SistemaCadastroDeHorasApi.Models.DTO;

public record ReqAtividadeUsuarioDTO(
    [Required,DataType(DataType.Date)]
    DateTime DataInicio,
    [Required,DataType(DataType.Date)]
    DateTime DataFim,
    [Required, Range(1, 15)]
    int TipoAtividadeId,
    [Required, Range(1, 2)]
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
    [Required]
    IFormFile comprovante,
    
    string? cnpj = null
){}