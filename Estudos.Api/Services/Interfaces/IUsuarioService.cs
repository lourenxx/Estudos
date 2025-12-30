using Estudos.Api.DTO;
using System.Threading.Tasks;

namespace Estudos.Api.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> CriarUsuario(CriarUsuarioDto dto);
        Task<string> DeletarUsuario(int id);
        Task<bool> AlterarUsuario(UsuarioDto dto);
        Task<List<UsuarioDto>> ListarUsuarios();
    }
}
