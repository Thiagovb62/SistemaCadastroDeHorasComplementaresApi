using Microsoft.AspNetCore.Mvc;
using SistemaCadastroDeHorasApi.Models.DTO;
using SistemaCadastroDeHorasApi.Services;

namespace SistemaCadastroDeHorasApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class Tipo_ParticipacaoController : ControllerBase
{
    private readonly ITipo_ParticipacaoService _tipoParticipacaoService;

    public Tipo_ParticipacaoController(ITipo_ParticipacaoService tipoParticipacaoService)
    {
        _tipoParticipacaoService = tipoParticipacaoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tiposParticipacao = await _tipoParticipacaoService.GetAllAsync();
        return Ok(tiposParticipacao);
    }

    [HttpGet]
    [Route("nome")]
    public async Task<IActionResult> GetByNome([FromQuery] string nome)
    {
        var tipoParticipacao = await _tipoParticipacaoService.GetByNomeAsync(nome);
        return Ok(tipoParticipacao);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var tipoParticipacao = await _tipoParticipacaoService.getByIdAsync(id);
        if (tipoParticipacao == null)
        {
            return NotFound($"Tipo de participação com ID {id} não encontrado.");
        }
        return Ok(tipoParticipacao);
    }

 
}

