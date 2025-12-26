using Estudos.Api.Database;
using Estudos.Api.DTO;
using Estudos.Api.Models;
using Estudos.Api.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace Estudos.Api.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DbEstudos _context;

        public UsuarioService(DbEstudos context)
        {
            _context = context;
        }

        public async Task<UsuarioDto> CriarUsuario(CriarUsuarioDto dto)
        {
            Usuario usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha,
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

        public async Task<string> DeletarUsuario(int id)
        {
            Usuario? usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return "Usuário não encontrado.";
            }
            else
            {
                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
                return $"Usuário {usuario.Id}: {usuario.Nome} deletado com sucesso!";
            }

        }
    }
}
