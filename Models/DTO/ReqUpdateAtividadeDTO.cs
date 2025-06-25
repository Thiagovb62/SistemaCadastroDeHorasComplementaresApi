namespace SistemaCadastroDeHorasApi.Models.DTO;

public record ReqUpdateAtividadeDTO(
    
    DateTime DataInicio,

    DateTime DataFim,

    int TipoAtividadeId,

    int TipoParticipacaoId,

    string? pais,

    string? titulo,

    string? nomeInstituicao,

    bool? isExecUfc,

    int cargaHoraria,

    int qtdHorasUtilizadas,

    IFormFile? comprovante,
    
    string? cnpj 
    );