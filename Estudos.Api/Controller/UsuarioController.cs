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
        public async Task<IActionResult> CriarUsuario(UsuarioDto usuarioDto)
        {
            var resultado = await _service.CriarUsuario(usuarioDto);
            return Ok(resultado);
        }
    }
}
