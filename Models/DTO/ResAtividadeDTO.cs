namespace SistemaCadastroDeHorasApi.Models.DTO;

public record ResAtividadeDTO(
    Guid id,
    DateTime DataInicio,
    DateTime DataFim,
    DateTime DataSubmissao,
    string status,
    string TipoAtividade,
    string TipoParticipacao,
    string Pais,
    string Titulo,
    string NomeInstituicao,
    bool IsExecUfc,
    int CargaHoraria,
    int QtdHorasUtilizadas,
    string Cnpj 
);
