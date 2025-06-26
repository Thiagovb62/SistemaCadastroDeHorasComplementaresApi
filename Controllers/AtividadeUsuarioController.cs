using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;
using SistemaCadastroDeHorasApi.Services;
using SistemaCadastroDeHorasApi.Services.Contracts;

namespace SistemaCadastroDeHorasApi.Controllers;
[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class AtividadeUsuarioController : ControllerBase
{

    private readonly IAtividadeUsuarioService _atividadeUsuarioService;
    
    private readonly IUsuarioService _usuarioService;

    private readonly IComprovanteService _comprovanteService;


    public AtividadeUsuarioController(IAtividadeUsuarioService atividadeUsuarioService, IUsuarioService usuarioService, IComprovanteService comprovanteService)
    {
        _usuarioService = usuarioService;
        _atividadeUsuarioService = atividadeUsuarioService;
        _comprovanteService = comprovanteService;
    }

    [HttpGet("atividade/all/{matricula}")]
    public async Task<IActionResult> GetAll([FromRoute] int matricula)
    {
        var atividadesUsuarios = await _atividadeUsuarioService.GetAllByUserMatriculaAsync(matricula);
        return Ok(atividadesUsuarios);
    }


    [HttpPost("add/atividade/{matricula}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Add([FromForm] ReqAtividadeUsuarioDTO dto, [FromRoute] int matricula)
    {
        var usuario = await _usuarioService.GetByMatriculaAsync(matricula);
        var atividade = new Atividades
        {
            Id = Guid.NewGuid(),
            TipoAtividadeId = dto.TipoAtividadeId,
            UsuarioId = usuario.Id ,
            TipoParticipacaoId = dto.TipoParticipacaoId,
            pais = dto.pais,
            titulo = dto.titulo,
            cargaHoraria = dto.cargaHoraria,
            dataInicio = dto.DataInicio,
            dataFim = dto.DataFim,
            nomeInstituicao = dto.nomeInstituicao,
            isExecUfc = dto.isExecUfc,
            qtdHorasUtilizadas = dto.qtdHorasUtilizadas,
            cnpj = dto.cnpj
        };

        await _atividadeUsuarioService.AddAsync(atividade, matricula, dto.comprovante);
        return Ok("Atividade adicionada com sucesso");
    }
    [HttpPut("atividade/{atividadeId}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Update([FromForm] ReqUpdateAtividadeDTO dto, [FromRoute] Guid atividadeId)
    {
        var updatedAtividade = await _atividadeUsuarioService.UpdateAsync(dto, atividadeId);
        return Ok(updatedAtividade);
    }
    
    [HttpDelete("delete/atividade/{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _atividadeUsuarioService.DeleteByAtividadeIdAsync(id);
        return Ok("Atividade deletada com sucesso");
    }

    [HttpGet("atividade/comprovante/{matricula}/{atividadeId}")]
    public async Task<IActionResult> GetComprovante([FromRoute] Guid atividadeId)
    {
        var comprovante = await _comprovanteService.GetComprovante(atividadeId);

        return File(comprovante, "application/pdf", "comprovante.pdf");
    }
    
}