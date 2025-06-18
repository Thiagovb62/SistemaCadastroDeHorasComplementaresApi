using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;
using SistemaCadastroDeHorasApi.Repositories;
using SistemaCadastroDeHorasApi.Repositories.Contracts;
using SistemaCadastroDeHorasApi.Services;
using SistemaCadastroDeHorasApi.Services.Contracts;

namespace SistemaCadastroDeHorasApi.Controllers;
[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
public class AtividadeUsuarioController: ControllerBase
{
    
    private readonly IAtividadeUsuarioService _atividadeUsuarioService;
    private readonly Tipo_AtividadeRepository _tipoAtividadeRepository;
    private readonly Tipo_ParticipacaoRepository _tipoParticipacaoRepository;
    

    public AtividadeUsuarioController(IAtividadeUsuarioService atividadeUsuarioService,
                                      Tipo_AtividadeRepository tipoAtividadeRepository,
                                      Tipo_ParticipacaoRepository tipoParticipacaoRepository)
    {
        _atividadeUsuarioService = atividadeUsuarioService;
        _tipoAtividadeRepository = tipoAtividadeRepository;
        _tipoParticipacaoRepository = tipoParticipacaoRepository;
    }

    // [HttpGet]
    // [Route("all")]
    // public async Task<IActionResult> GetAll()
    // {
    //     var atividadesUsuarios = await _atividadeUsuarioService.GetAllAsync();
    //     return Ok(atividadesUsuarios);
    // }
    //
    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetByUserId(int id)
    // {
    //     var atividadesUsuarios = await _atividadeUsuarioService.GetByUserIdAsync(id);
    //     return Ok(atividadesUsuarios);
    // }

    [HttpPost("add/{usuarioId}")]
    public async Task<IActionResult> Add([FromBody] ReqAtividadeUsuarioDTO dto, [FromRoute] int usuarioId)
    {
        var atividade = new Atividades
        {
            Id = Guid.NewGuid(),
            TipoAtividadeId = dto.TipoAtividadeId,
            TipoParticipacaoId = dto.TipoParticipacaoId,
            pais = dto.pais,
            titulo = dto.titulo,
            cargaHoraria = dto.cargaHoraria,
            dataInicio = dto.DataInicio,
            dataFim = dto.DataFim,
            nomeInstituicao = dto.nomeInstituicao,
            isExecUfc = dto.isExecUfc,
            qtdHorasUtilizadas = dto.qtdHorasUtilizadas,
            TipoAtividade = _tipoAtividadeRepository.GetByIdAsync(dto.TipoAtividadeId).Result,
            TipoParticipacao = _tipoParticipacaoRepository.getByIdAsync(dto.TipoParticipacaoId).Result,
            cnpj = dto.cnpj
        };
        await _atividadeUsuarioService.AddAsync(atividade, usuarioId);
        return Ok("Atividade adicionada com sucesso");
}

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> Delete(int id)
    // {
    //     await _atividadeUsuarioService.DeleteAsync(id);
    //     return NoContent();
    // }
    
}