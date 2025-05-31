using Microsoft.AspNetCore.Mvc;
using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Services;
using System.Threading.Tasks;

namespace SistemaCadastroDeHorasApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _usuarioService.GetAllAsync();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var usuario = await _usuarioService.GetByIdAsync(id);
        if (usuario == null) return NotFound();
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Usuario usuario)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var createdUsuario = await _usuarioService.CreateAsync(usuario);
        return CreatedAtAction(nameof(GetById), new { id = createdUsuario.Id }, createdUsuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Usuario usuario)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var updatedUsuario = await _usuarioService.UpdateAsync(id, usuario);
        if (updatedUsuario == null) return NotFound();

        return Ok(updatedUsuario);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _usuarioService.DeleteAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}
