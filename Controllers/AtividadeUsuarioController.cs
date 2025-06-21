using Microsoft.AspNetCore.Mvc;
using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;
using SistemaCadastroDeHorasApi.Repositories;
using SistemaCadastroDeHorasApi.Repositories.Contracts;
using SistemaCadastroDeHorasApi.Services.Contracts;

namespace SistemaCadastroDeHorasApi.Controllers;
[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class AtividadeUsuarioController : ControllerBase
{

    private readonly IAtividadeUsuarioService _atividadeUsuarioService;



    public AtividadeUsuarioController(IAtividadeUsuarioService atividadeUsuarioService)
    {
        _atividadeUsuarioService = atividadeUsuarioService;
    }

    [HttpGet("atividadeUsuario/allAtividades/{userId}")]
    public async Task<IActionResult> GetAll([FromRoute] int userId)
    {
        var atividadesUsuarios = await _atividadeUsuarioService.GetAllByUserIdAsync(userId);
        return Ok(atividadesUsuarios);
    }


    [HttpPost("add/{usuarioId}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Add([FromForm] ReqAtividadeUsuarioDTO dto, [FromRoute] int usuarioId)
    {
        var atividade = new Atividades
        {
            Id = Guid.NewGuid(),
            TipoAtividadeId = dto.TipoAtividadeId,
            UsuarioId = usuarioId,
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

        await _atividadeUsuarioService.AddAsync(atividade, usuarioId, dto.comprovante);
        return Ok("Atividade adicionada com sucesso");
    }

    
}