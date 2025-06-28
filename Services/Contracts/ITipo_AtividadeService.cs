using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;

namespace SistemaCadastroDeHorasApi.Services;

public interface ITipo_AtividadeService
{
    Task<ResTipoAtividadeDTO> GetByNomeAsync(string nome);
    Task<IEnumerable<ResTipoAtividadeDTO>> GetAllAsync();
    Task<ResTipoAtividadeDTO> GetByIdAsync(int id);

    
    
}