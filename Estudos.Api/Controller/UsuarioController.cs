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

        [HttpDelete]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            try
            {
                var resultado = await _service.DeletarUsuario(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
