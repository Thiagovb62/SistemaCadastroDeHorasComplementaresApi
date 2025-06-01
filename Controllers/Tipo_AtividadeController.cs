using Microsoft.AspNetCore.Mvc;
using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;

namespace SistemaCadastroDeHorasApi.Controllers;
using Services;

[ApiController]
[Route("api/[controller]/tipo-atividade")]
[Produces("application/json")]
[Consumes("application/json")]
public class Tipo_AtividadeController: ControllerBase
{
    private readonly ITipo_AtividadeService _tipoAtividadeService;
    public Tipo_AtividadeController( ITipo_AtividadeService tipoAtividadeService)
    {
        _tipoAtividadeService =  tipoAtividadeService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tiposAtividade = await _tipoAtividadeService.GetAllAsync();
        return Ok(tiposAtividade);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReqTipo_AtividadeDTO dto)
    {
        if (dto == null)
        {
            return BadRequest("Tipo de atividade não pode ser nulo.");
        }

        var createdTipoAtividade = await _tipoAtividadeService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id = createdTipoAtividade.Id }, createdTipoAtividade);
    }
    
}