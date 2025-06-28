using SistemaCadastroDeHorasApi.Models;

namespace SistemaCadastroDeHorasApi.Repositories;

public interface ITipo_AtividadeRepository
{

    Task<IEnumerable<Tipo_Atividade>> GetAllAsync();
    Task<Tipo_Atividade> GetByNomeAsync(String nome);
    Task<Tipo_Atividade> GetByIdAsync(int id);
    
}