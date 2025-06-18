using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;

namespace SistemaCadastroDeHorasApi.Services;
public interface ITipo_ParticipacaoService
{
    Task<ResTipoParticipacaoDTO> GetByNomeAsync(string nome);
    Task<IEnumerable<ResTipoParticipacaoDTO>> GetAllAsync();
    Task<ResTipoParticipacaoDTO> getByIdAsync(int id);
}

