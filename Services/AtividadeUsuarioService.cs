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
    private readonly IComprovanteService _comprovanteService;
    public AtividadeUsuarioService(IAtividadeUsuarioRepository atividadeUsuarioRepositoryRepository, IAtividadesRepository atividadesRepository, IUsuarioRepository usuarioRepository, IComprovanteService comprovanteAuxiliary)
    {
        _atividadeUsuarioRepositoryRepository = atividadeUsuarioRepositoryRepository;
        _atividadesRepository = atividadesRepository;
        _usuarioRepository = usuarioRepository;
        _comprovanteService = comprovanteAuxiliary;
    }
    public Task<IEnumerable<ResAtividadeUsario>> GetAllAsync()
    {
        return Task.FromResult(_atividadeUsuarioRepositoryRepository.GetAllAsync().Result.Select(a => new ResAtividadeUsario(
            a.Id,
            a.Usuario,
            a.Atividade,
            a.Atividade.nomeArquivo,
            a.Atividade.tipoArquivo
        )));
    }

    public Task<IEnumerable<ResAtividadeUsario>> GetAllByUserIdAsync(int id)
    {
        var atividades =  _atividadesRepository.GetByUserIdAsync(id).Result;
        var user =  _usuarioRepository.GetByIdAsync(id).Result;
        
        return Task.FromResult(atividades.Select(a => new ResAtividadeUsario(
            a.Id,
            user,
            a,
            a.nomeArquivo,
            a.tipoArquivo
        )));
            
    }

    public async Task AddAsync(Atividades atividade, int usuarioId, IFormFile comprovante)
    {
        var (arquivo, nomeArquivo, tipoArquivo) = _comprovanteService.ConvertComprovante(comprovante);
        atividade.comprovante = arquivo;
        atividade.nomeArquivo = nomeArquivo;
        atividade.tipoArquivo = tipoArquivo;
        
        await _atividadeUsuarioRepositoryRepository.AddAsync(atividade, usuarioId);
         
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}