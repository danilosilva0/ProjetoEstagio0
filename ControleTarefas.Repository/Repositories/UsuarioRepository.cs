using ControleTarefas.Entity.DTO;
using ControleTarefas.Entity.Entities;
using ControleTarefas.Repository.Interface.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private static List<Usuario> Usuarios { set; get; } = new();

        public void Deletar(Usuario usuario)
        {
            Usuarios.Remove(usuario);
        }

        public void Editar(string usuario, string novoNomeUsuario)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }

        public List<UsuarioDTO> ListarUsuariosDTO(List<string> emails)
        {
            return Usuarios.Where(usuario => emails.Contains(usuario.Email.ToUpper()))
                .OrderBy(usuario => usuario.Nome)
                .Distinct()
                .Select(usuario => new UsuarioDTO
                {
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    DataAtualizacao = usuario.DataAtualizacao,
                    Perfil = usuario.Perfil
                })
                .ToList();
        }

        public List<UsuarioDTO> ListarTodosUsuariosDTO()
        {
            return Usuarios.OrderBy(usuario => usuario.Nome)
                .Distinct()
                .Select(usuario => new UsuarioDTO
                {
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    DataAtualizacao = usuario.DataAtualizacao,
                    Perfil = usuario.Perfil
                })
                .ToList();
        }

        public Usuario ObterUsuario(string email)
        {
            return Usuarios.FirstOrDefault(e => e.Email.ToLower() == email.ToLower());
        }
    }
}
