using Microsoft.AspNetCore.Mvc;
using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Services;
using SistemaCadastroDeHorasApi.Models.DTO;

namespace SistemaCadastroDeHorasApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AtividadesController : ControllerBase
{
    private readonly IAtividadesService _service;

    public AtividadesController(IAtividadesService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var atividades = await _service.GetAll();
        return Ok(atividades);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var atividade = await _service.GetById(id);
        if (atividade == null) return NotFound();
        return Ok(atividade);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Atividades atividade)
    {
        await _service.Create(atividade);
        return CreatedAtAction(nameof(Get), new { id = atividade.Id }, atividade);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] Atividades atividade)
    {
        if (id != atividade.Id) return BadRequest("ID mismatch");
        await _service.Update(atividade);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
