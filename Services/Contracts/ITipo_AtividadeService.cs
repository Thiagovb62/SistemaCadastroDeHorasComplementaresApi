using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;

namespace SistemaCadastroDeHorasApi.Services;

public interface ITipo_AtividadeService
{
    Task<ResTipoAtividadeDTO> GetByNomeAsync(string nome);
    Task<IEnumerable<ResTipoAtividadeDTO>> GetAllAsync();
    Task<Tipo_Atividade> CreateAsync(ReqTipo_AtividadeDTO dto);
    Task<ResTipoAtividadeDTO> GetByIdAsync(int id);

    
    
}