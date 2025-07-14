using Microsoft.AspNetCore.Mvc;
    using SistemaCadastroDeHorasApi.Services;
    using SistemaCadastroDeHorasApi.Models.DTO;
    using System.ComponentModel.DataAnnotations;
    using SistemaCadastroDeHorasApi.Models;
    
    namespace SistemaCadastroDeHorasApi.Controllers;
    
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
    
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        
        [EndpointSummary("Obtém todos os usuários")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ResUserDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioService.GetAllAsync();
            return Ok(usuarios);
        }
    
       
        [EndpointSummary("Obtém um usuário pelo matrícula")]
        [HttpGet("{matricula}")]
        [ProducesResponseType(typeof(ResUserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int matricula)
        {
            var usuario = await _usuarioService.GetByMatriculaAsync(matricula);
            // O serviço já deve tratar o caso de não encontrar, lançando uma exceção que resultaria em 404.
            return Ok(usuario);
        }
    
       
        [EndpointSummary("Cria um novo usuário")]
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ReqUserDTO usuario)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            await _usuarioService.CreateAsync(usuario);
            
            return Ok("Usuário criado com sucesso.");
        }
    
        
        [EndpointSummary("Atualiza um usuário pelo ID")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResUserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] ReqUpdateUserDTO usuario)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
    
            var updatedUsuario = await _usuarioService.UpdateAsync(id, usuario);
            if (updatedUsuario == null) return NotFound();
    
            return Ok(updatedUsuario);
        }
    
        
        [EndpointSummary("Deleta um usuário pelo matrícula")]
        [HttpDelete("{matricula}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int matricula)
        {
            var deleted = await _usuarioService.DeleteAsync(matricula);
            if (!deleted) return NotFound("Usuário não encontrado.");
    
            return NoContent();
        }
        
        [EndpointSummary("Atualiza o limite de horas de um usuário")]
        [HttpPut("updateLimiteHoras/{matricula}")]
        [ProducesResponseType(typeof(ResUserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateLimiteHoras([FromRoute] int matricula, [FromBody] ReqUpdateLimiteHorasDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
    
            var result = await _usuarioService.updateLimiteHorasAsync(matricula, dto);
            return Ok(result);
        }
    }