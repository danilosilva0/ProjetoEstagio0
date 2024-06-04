using ControleTarefas.Entity.DTO;
using ControleTarefas.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Service.Interface.Services
{
    public interface IUsuarioService
    {
        //List<UsuarioDTO> DeletarUsuario(string email);
        //List<UsuarioDTO> EditarUsuario(string usuario, string novoNomeUsuario);
        List<UsuarioDTO> InserirUsuario(CadastroUsuarioModel usuario);
        //List<UsuarioDTO> ListarUsuariosDTO(List<string> usuarios);
    }
}
