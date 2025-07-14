using Microsoft.AspNetCore.Mvc;
using SistemaCadastroDeHorasApi.Models.ENUMS;
namespace SistemaCadastroDeHorasApi.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[Produces("application/json")]
public class CategoriaAtividadeController : ControllerBase
{
    [HttpGet("atividade/categorias")]
    public IActionResult GetAtividadeCategorias()
    {
        var categorias = Enum.GetValues(typeof(CategoriaAtividadeComplementarEnum))
            .Cast<CategoriaAtividadeComplementarEnum>()
            .Select(c => new { Id = (int)c, Nome = c.ToString() });

        return Ok(categorias);
    }
}

