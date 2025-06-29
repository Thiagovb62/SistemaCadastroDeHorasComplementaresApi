using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;

namespace SistemaCadastroDeHorasApi.Services.Contracts;

public interface IAtividadeUsuarioService
{

    Task<IEnumerable<ResAtividadeUsario>> GetAllByUserMatriculaAsync(int matriucla);
    void AddAsync(ReqAtividadeUsuarioDTO dto, int matricula, IFormFile comprovante);
    void IntegralizarHoras(Guid atividadeId);
    Task<string> UpdateAsync(ReqUpdateAtividadeDTO dto, Guid atividadeId);
    Task DeleteByAtividadeIdAsync(Guid id);
    Task<IEnumerable<ResHoraDetailsDTO>> GetHorasDeatailsByMatricula(int matricula);
    int GetTipoAtividadeComplementarByIdAsync(int matricula,int codigo);
}