using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;
using SistemaCadastroDeHorasApi.Models.ENUMS;
using SistemaCadastroDeHorasApi.Repositories;

namespace SistemaCadastroDeHorasApi.Services;
public class Tipo_ParticipacaoService : ITipo_ParticipacaoService
{
    private readonly ITipo_ParticipacaoRepository _tipoParticipacaoRepository;

    public Tipo_ParticipacaoEnum? ObterTipoParticipacaoPorNome(string nome)
    {
        return Tipo_ParticipacaoEnumExtensions.FromString(nome);
    }

    public string ObterNomeTipoParticipacao(int valor)
    {
        return Enum.GetName(typeof(Tipo_ParticipacaoEnum), valor) ?? "Valor invalido";
    }

    public Tipo_ParticipacaoService(ITipo_ParticipacaoRepository tipoParticipacaoRepository)
    {
        _tipoParticipacaoRepository = tipoParticipacaoRepository;
    }

    public async Task<ResTipoParticipacaoDTO> GetByNomeAsync(string nome)
    {
        if (string.IsNullOrEmpty(nome)) 
        {
            throw new ArgumentNullException("Nome do tipo de participação não pode ser nulo ou vazio.", nameof(nome));
        }

        var tipoParticipacao = await _tipoParticipacaoRepository.GetByNomeAsync(nome);

        if (tipoParticipacao == null)
        {
            throw new KeyNotFoundException($"Tipo de participação '{nome}' não encontrado.");
        }

        return new ResTipoParticipacaoDTO
        {
            Id = tipoParticipacao.Id,
            nome = ObterNomeTipoParticipacao((int)tipoParticipacao.nome)
        };
    }

    public async Task<IEnumerable<ResTipoParticipacaoDTO>> GetAllAsync()
    {
        var tiposParticipacao = await _tipoParticipacaoRepository.GetAllAsync();

        if (tiposParticipacao == null || !tiposParticipacao.Any())
        {
            throw new InvalidOperationException("Nenhum tipo de participação encontrado.");
        }

        return tiposParticipacao.Select(tipo => new ResTipoParticipacaoDTO
        {
            Id = tipo.Id,
            nome = ObterNomeTipoParticipacao((int)tipo.nome)
        });
    }

    public Task<ResTipoParticipacaoDTO> getByIdAsync(int id)
    {
        var tipoParticipacao = _tipoParticipacaoRepository.getByIdAsync(id)
            .Result;

        if (tipoParticipacao == null)
        {
            throw new KeyNotFoundException($"Tipo de participação com ID {id} não encontrado.");
        }

        return Task.FromResult(new ResTipoParticipacaoDTO
        {
            Id = tipoParticipacao.Id,
            nome = ObterNomeTipoParticipacao((int)tipoParticipacao.nome)
        });
    }
    
}

