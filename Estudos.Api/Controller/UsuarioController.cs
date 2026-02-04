using Azure.Core.Pipeline;
using Estudos.Api.DTO;
using Estudos.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.Api.Controller
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            try
            {
                var resultado = await _service.ListarUsuarios();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarUsuarioPorId(int id)
        {
            try
            {
                var resultado = await _service.BuscarUsuarioPorId(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario(CriarUsuarioDto dto)
        {
            try
            {
                var resultado = await _service.CriarUsuario(dto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AlterarUsuario(UsuarioDto dto)
        {
            try
            {
                var resultado = await _service.AlterarUsuario(dto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirUsuario(int id)
        {
            try
            {
                var resultado = await _service.ExcluirUsuario(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
