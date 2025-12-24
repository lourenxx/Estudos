using Estudos.Api.Database;
using Estudos.Api.DTO;
using Estudos.Api.Models;
using Estudos.Api.Services.Interfaces;

namespace Estudos.Api.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DbEstudos _context;

        public UsuarioService(DbEstudos context)
        {
            _context = context;
        }

        public async Task<UsuarioDto> CriarUsuario(UsuarioDto usuarioDto)
        {
            Usuario usuario = new Usuario
            {
                Id = usuarioDto.Id,
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                Senha = usuarioDto.Senha,
                DataCriacao = DateTime.Now
            };

            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                DataCriacao = usuario.DataCriacao
                
            };
        }
    }
}
