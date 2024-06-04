using ControleTarefas.Entity.DTO;
using ControleTarefas.Entity.Entities;
using ControleTarefas.Entity.Model;
using ControleTarefas.Helper.Exceptions;
using ControleTarefas.Helper.Messages;
using ControleTarefas.Repository.Interface.IRepositories;
using ControleTarefas.Service.Interface.Services;
using log4net;

namespace ControleTarefas.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(UsuarioService));
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository) { _usuarioRepository = usuarioRepository;}

        //public List<UsuarioDTO> DeletarUsuario(string nomeUsuario)
        //{
        //    var usuario = _usuarioRepository.ObterUsuario(nomeUsuario);
        //    if (usuario != null)
        //    {
        //        _usuarioRepository.Deletar(usuario);
        //        _log.InfoFormat("A usuario '{0}' foi deletada com sucesso!", nomeUsuario);
        //    }
        //    else
        //    {
        //        _log.InfoFormat("A usuario '{0}' não existe na lista de usuarios.", nomeUsuario);
        //        throw new ServiceException(string.Format(BusinessMessages.RegisterNotFound, nomeUsuario));
        //    }

        //    return _usuarioRepository.ListarTodosUsuariosDTO();
        //}

        //public List<UsuarioDTO> EditarUsuario(string usuario, string novoNomeUsuario)
        //{


        //    var usuarioExistente = _usuarioRepository.ObterUsuario(usuario);
        //    if (usuarioExistente != null)
        //    {
        //        usuarioExistente.Titulo = novoNomeUsuario;
        //        _log.InfoFormat("A usuario '{0}' foi editada para '{1}' com sucesso!", usuario, novoNomeUsuario);
        //    }
        //    else
        //    {
        //        _log.InfoFormat("A usuario '{0}' nao existe na lista de usuarios.", usuario);
        //        throw new ServiceException($"A usuario {usuario} nao existe na lista de usuarios");
        //    }

        //    return _usuarioRepository.ListarTodosUsuariosDTO();
        //}

        public List<UsuarioDTO> InserirUsuario(CadastroUsuarioModel novoUsuario)
        {
            var usuario = _usuarioRepository.ObterUsuario(novoUsuario.Email);

            if (usuario != null)
            {
                _log.InfoFormat(ServiceMessages.ExistentRegister, usuario.Nome);
                throw new ServiceException(string.Format(ServiceMessages.ExistentRegister, usuario.Nome));            }
            usuario = new Usuario
            {
                Email = novoUsuario.Email,
                Nome = novoUsuario.Nome,
                DataAtualizacao = DateTime.Now,
                Perfil = novoUsuario.Perfil
            };

            _usuarioRepository.Inserir(usuario);

            return _usuarioRepository.ListarTodosUsuariosDTO();

            //usuario = new Usuario(novaUsuario);
            //_usuarioRepository.Inserir(usuario);
            //_log.InfoFormat("A usuario '{0}' foi inserida com sucesso!", novaUsuario);

        }

        //public List<UsuarioDTO> ListarUsuariosDTO(List<string> usuarios) 
        //{
        //    if (usuarios == null) return _usuarioRepository.ListarTodosUsuariosDTO();
        //    else
        //    {
        //        usuarios = usuarios.Select(t => t.ToUpper()).ToList();
        //        return _usuarioRepository.ListarUsuariosDTO(usuarios);
        //    }
        //}
    }
}
