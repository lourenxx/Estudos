using Estudos.Api.Database;
using Estudos.Api.DTO;
using Estudos.Api.Models;
using Estudos.Api.Security;
using Estudos.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<UsuarioDto>> ListarUsuarios()
        {
            List<Usuario> usuarios = await _context.Usuario.ToListAsync();

            List<UsuarioDto> listaUsuarios = usuarios.Select(u => new UsuarioDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                Senha = u.Senha,
                DataCriacao = u.DataCriacao

            }).ToList();

            return listaUsuarios;

        }

        public async Task<UsuarioDto> BuscarUsuarioPorId(int id)
        {

            Usuario? usuario = await _context.Usuario.FindAsync(id);


            if(usuario == null)
            {
                return new UsuarioDto();
            }
            else
            {
                return new UsuarioDto()
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    DataCriacao = usuario.DataCriacao
                };
            }
        }

        public async Task<UsuarioDto> CriarUsuario(CriarUsuarioDto dto)
        {
            Usuario usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = HashPassword.Hash(dto.Senha),
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

        public async Task<bool> AlterarUsuario(UsuarioDto dto)
        {


            Usuario usuario = await _context.Usuario.FindAsync(dto.Id);

            if (usuario == null)
            {
                return false;
            }
            else
            {

                usuario.Nome = dto.Nome;
                usuario.Email = dto.Email;
                usuario.Senha = HashPassword.Hash(dto.Senha);

                await _context.SaveChangesAsync();

                return true;
            }

        }

        public async Task<string> ExcluirUsuario(int id)
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
