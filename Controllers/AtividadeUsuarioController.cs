using Microsoft.AspNetCore.Mvc;
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



    public AtividadeUsuarioController(IAtividadeUsuarioService atividadeUsuarioService, IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
        _atividadeUsuarioService = atividadeUsuarioService;
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

    
}