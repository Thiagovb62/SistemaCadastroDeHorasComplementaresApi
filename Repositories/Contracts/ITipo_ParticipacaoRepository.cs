using SistemaCadastroDeHorasApi.Models;

namespace SistemaCadastroDeHorasApi.Repositories;
public interface ITipo_ParticipacaoRepository
{
    Task<IEnumerable<Tipo_Participacao>> GetAllAsync();
    Task<Tipo_Participacao> GetByNomeAsync(String nome);
    //Task<Tipo_Participacao> CreateAsync(Tipo_Participacao tipoParticipacao);
}
