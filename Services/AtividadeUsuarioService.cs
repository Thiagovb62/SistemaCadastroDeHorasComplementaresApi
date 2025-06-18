using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;
using SistemaCadastroDeHorasApi.Repositories;
using SistemaCadastroDeHorasApi.Repositories.Contracts;
using SistemaCadastroDeHorasApi.Services.Contracts;

namespace SistemaCadastroDeHorasApi.Services;

public class AtividadeUsuarioService: IAtividadeUsuarioService
{
    
    private readonly IAtividadeUsuarioRepository _atividadeUsuarioRepositoryRepository;
    private readonly IAtividadesRepository _atividadesRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    public AtividadeUsuarioService(IAtividadeUsuarioRepository atividadeUsuarioRepositoryRepository, IAtividadesRepository atividadesRepository, IUsuarioRepository usuarioRepository)
    {
        _atividadeUsuarioRepositoryRepository = atividadeUsuarioRepositoryRepository;
        _atividadesRepository = atividadesRepository;
        _usuarioRepository = usuarioRepository;
    }
    public Task<IEnumerable<ResAtividadeUsario>> GetAllAsync()
    {
        return Task.FromResult(_atividadeUsuarioRepositoryRepository.GetAllAsync().Result.Select(a => new ResAtividadeUsario(
            a.Id,
            a.Usuario,
            a.Atividade
        )));
    }

    public Task<IEnumerable<ResAtividadeUsario>> GetAllByUserIdAsync(int id)
    {
        var atividades =  _atividadesRepository.GetByUserIdAsync(id).Result;
        var user =  _usuarioRepository.GetByIdAsync(id).Result;
        
        return Task.FromResult(atividades.Select(a => new ResAtividadeUsario(
            a.Id,
            user,
            a
        )));
            
    }

    public async Task AddAsync(Atividades atividade, int usuarioId)
    {
        
        await _atividadeUsuarioRepositoryRepository.AddAsync(atividade,usuarioId);
         
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}