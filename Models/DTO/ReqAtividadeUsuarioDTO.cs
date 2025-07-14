using System.ComponentModel.DataAnnotations;

namespace SistemaCadastroDeHorasApi.Models.DTO;

public record ReqAtividadeUsuarioDTO(
    [Required,DataType(DataType.Date)]
    [Range(typeof(DateTime), "2020-01-01", "2100-12-31", ErrorMessage = "A data de início deve estar entre 01/01/2020 e 31/12/2100")]
    DateTime DataInicio,
    [Required,DataType(DataType.Date)]
    [Range(typeof(DateTime), "2020-01-01", "2100-12-31", ErrorMessage = "A data de fim deve estar entre 01/01/2020 e 31/12/2100")]
    DateTime DataFim,
    [Required (ErrorMessage = "O campo 'Tipo de Atividade' é obrigatório")]
    [Range(1, 15, ErrorMessage = "O tipo de atividade deve ser um número inteiro entre 1 e 15")]
    int TipoAtividadeId,
    [Required (ErrorMessage = "O campo 'Tipo de Participação' é obrigatório")]
    [Range(1, 2, ErrorMessage = "O tipo de participação deve ser um número inteiro entre 1 e 2")]
    int TipoParticipacaoId,
    [Required, StringLength(100, MinimumLength = 3)]
    string pais,
    [Required (ErrorMessage = "O campo 'Título' é obrigatório")]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "O título deve ter entre 3 e 200 caracteres")]
    string titulo,
    [Required (ErrorMessage = "O campo 'Nome da Instituição' é obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da instituição deve ter entre 3 e 100 caracteres")]
    string nomeInstituicao,
    [Required  (ErrorMessage = "O campo 'É Executado na UFC' é obrigatório")]
    bool isExecUfc,
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Carga horária deve ser um número positivo maior que zero")]
    int cargaHoraria,
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantidade de horas utilizadas deve ser um número positivo maior que zero")]
    int qtdHorasUtilizadas,
    [Required (ErrorMessage = "O comprovante é obrigatório")]
    [DataType(DataType.Upload)]
    IFormFile comprovante,
    
    string? cnpj = null
){}