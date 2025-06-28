using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;
using SistemaCadastroDeHorasApi.Models.ENUMS;
using SistemaCadastroDeHorasApi.Repositories;

namespace SistemaCadastroDeHorasApi.Services;

public class Tipo_AtividadeService : ITipo_AtividadeService
{
    private readonly ITipo_AtividadeRepository _tipoAtividadeRepository;
    
    public Tipo_AtividadeEnum? ObterTipoAtividadePorNome(string nome)
    {
        return Tipo_AtividadeEnumExtensions.FromString(nome);
    }
    
    public string ObterNomeTipoAtividade(int valor)
    {
        return Enum.GetName(typeof(Tipo_AtividadeEnum), valor) ?? "Valor inválido";
    }

    public Tipo_AtividadeService(ITipo_AtividadeRepository tipoAtividadeRepository)
    {
        _tipoAtividadeRepository = tipoAtividadeRepository;
    }
    
    public async Task<ResTipoAtividadeDTO> GetByNomeAsync(string nome)
    {
        if (string.IsNullOrEmpty(nome))
        {
            throw new ArgumentException("Nome do tipo de atividade não pode ser nulo ou vazio.", nameof(nome));
        }

        var tipoAtividade = await _tipoAtividadeRepository.GetByNomeAsync(nome);

        if (tipoAtividade == null)
        {
            throw new KeyNotFoundException($"Tipo de atividade '{nome}' não encontrado.");
        }

        return new ResTipoAtividadeDTO
        {
            Id = tipoAtividade.Id,
            nome = ObterNomeTipoAtividade((int)tipoAtividade.nome)
        };
    }
    
    public async Task<IEnumerable<ResTipoAtividadeDTO>> GetAllAsync()
    {
        var tiposAtividade = await _tipoAtividadeRepository.GetAllAsync();

        if (tiposAtividade == null || !tiposAtividade.Any())
        {
            throw new InvalidOperationException("Nenhum tipo de atividade encontrado.");
        }

        return tiposAtividade.Select(tipo => new ResTipoAtividadeDTO
        {
            Id = tipo.Id,
            nome = ObterNomeTipoAtividade((int)tipo.nome)
        });
    }
    

    public Task<ResTipoAtividadeDTO> GetByIdAsync(int id)
    {

        var tipoAtividade = _tipoAtividadeRepository.GetByIdAsync(id)
            .Result;

        if (tipoAtividade == null)
        {
            throw new KeyNotFoundException($"Tipo de atividade com ID {id} não encontrado.");
        }

        return Task.FromResult(new ResTipoAtividadeDTO
        {
            Id = tipoAtividade.Id,
            nome = ObterNomeTipoAtividade((int)tipoAtividade.nome)
        });
    }
}