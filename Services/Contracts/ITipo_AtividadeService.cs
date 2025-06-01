using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;

namespace SistemaCadastroDeHorasApi.Services;

public interface ITipo_AtividadeService
{
    Task<IEnumerable<ResTipoAtividadeDTO>> GetAllAsync();
    Task<Tipo_Atividade> CreateAsync(ReqTipo_AtividadeDTO dto);

    
    
}