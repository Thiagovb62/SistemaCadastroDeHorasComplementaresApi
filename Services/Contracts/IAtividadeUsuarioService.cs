using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;

namespace SistemaCadastroDeHorasApi.Services.Contracts;

public interface IAtividadeUsuarioService
{

    Task<IEnumerable<ResAtividadeUsario>> GetAllByUserMatriculaAsync(int matriucla);
    void AddAsync(ReqAtividadeUsuarioDTO dto, int matricula);
    void IntegralizarHoras(Guid atividadeId);
    Task<string> UpdateAsync(ReqUpdateAtividadeDTO dto, Guid atividadeId);
    Task DeleteByAtividadeIdAsync(Guid id);
}