using Estudos.Api.DTO;

namespace Estudos.Api.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> CriarUsuario(UsuarioDto usuarioDto);
    }
}
