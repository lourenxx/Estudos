using Estudos.Api.DTO;
using System.Threading.Tasks;

namespace Estudos.Api.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDto>> ListarUsuarios();
        Task<UsuarioDto> BuscarUsuarioPorId(int id);
        Task<UsuarioDto> CriarUsuario(CriarUsuarioDto dto);
        Task<bool> AlterarUsuario(UsuarioDto dto);
        Task<string> DeletarUsuario(int id);
  

    }
}
