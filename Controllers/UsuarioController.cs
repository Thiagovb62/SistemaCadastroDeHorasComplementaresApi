using Microsoft.AspNetCore.Mvc;
using SistemaCadastroDeHorasApi.Services;
using SistemaCadastroDeHorasApi.Models.DTO;

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

    [HttpGet("{matricula}")]
    public async Task<IActionResult> GetById(int matricula)
    {
        var usuario = await _usuarioService.GetByMatriculaAsync(matricula);
        
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReqUserDTO usuario)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var createdUsuario = await _usuarioService.CreateAsync(usuario);
        return CreatedAtAction(nameof(GetById), new { id = createdUsuario.Id }, createdUsuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ReqUpdateUserDTO usuario)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var updatedUsuario = await _usuarioService.UpdateAsync(id, usuario);
        if (updatedUsuario == null) return NotFound();

        return Ok(updatedUsuario);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int matricula)
    {
        var deleted = await _usuarioService.DeleteAsync(matricula);
        if (!deleted) return NotFound("Usuário não encontrado.");

        return NoContent();
    }
}
