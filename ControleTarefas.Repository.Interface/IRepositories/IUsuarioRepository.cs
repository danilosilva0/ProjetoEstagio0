using ControleTarefas.Entity.DTO;
using ControleTarefas.Entity.Entities;
using ControleTarefas.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Repository.Interface.IRepositories
{
    public interface IUsuarioRepository
    {
        void Deletar(Usuario usuario);
        void Editar(string usuario, string novoNomeUsuario);
        void Inserir(Usuario usuario);
        List<UsuarioDTO> ListarUsuariosDTO(List<string> emails);
        List<UsuarioDTO> ListarTodosUsuariosDTO();
        Usuario ObterUsuario(string email);
    }
}
