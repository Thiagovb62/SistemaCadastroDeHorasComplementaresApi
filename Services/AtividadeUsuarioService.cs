using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;
using SistemaCadastroDeHorasApi.Repositories.Contracts;
using SistemaCadastroDeHorasApi.Services.Contracts;

namespace SistemaCadastroDeHorasApi.Services;

public class AtividadeUsuarioService: IAtividadeUsuarioService
{
    
    private readonly IAtividadeUsuarioRepository _atividadeUsuarioRepositoryRepository;
    public AtividadeUsuarioService(IAtividadeUsuarioRepository atividadeUsuarioRepositoryRepository)
    {
        _atividadeUsuarioRepositoryRepository = atividadeUsuarioRepositoryRepository;
    }
    public Task<IEnumerable<ResAtividadeUsario>> GetAllAsync()
    {
        return Task.FromResult(_atividadeUsuarioRepositoryRepository.GetAllAsync().Result.Select(a => new ResAtividadeUsario(
            a.Id,
            a.Usuario,
            a.Atividade
        )));
    }

    public Task<IEnumerable<ResAtividadeUsario>> GetByUserIdAsync(int id)
    {
        IEnumerable<AtividadeUsuario> atividades = _atividadeUsuarioRepositoryRepository.GetByUsuarioIdAsync(id).Result;
        
        return new Task<IEnumerable<ResAtividadeUsario>>(() => atividades.Select(a => new ResAtividadeUsario(
            a.Id,
            a.Usuario,
            a.Atividade
        )));
    }

    public Task AddAsync(Atividades atividade, int usuarioId)
    {

        return _atividadeUsuarioRepositoryRepository.AddAsync(atividade, usuarioId);
         
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}