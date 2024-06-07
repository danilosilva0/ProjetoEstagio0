using ControleTarefas.Entity.DTO;
using ControleTarefas.Entity.Entities;
using ControleTarefas.Entity.Model;
using ControleTarefas.Service.Interface.Services;
using ControleTarefas.WebApi;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ProjetoEstagioPitang.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private static List<string> Tarefas { get; set; } = new() { "Tarefa0", "Tarefa1", "Tarefa2", "Tarefa3" };
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        //[HttpGet("BuscarTarefas")]
        //public ActionResult<List<UsuarioDTO>> ListarTodasTarefas()
        //{
        //    return _usuarioService.ListarTarefasDTO(null);
        //}

        //[HttpGet("FiltrarTarefas")]
        //public ActionResult<List<UsuarioDTO>> FiltrarTarefas(string tarefas)
        //{
        //    return _usuarioService.ListarTarefasDTO(new List<string>() { tarefas });
        //}

        [HttpPost("InserirUsuario")]
        public ActionResult<List<UsuarioDTO>> Post(CadastroUsuarioModel usuario)
        {
            return _usuarioService.InserirUsuario(usuario);
        }

        //[HttpPut("EditarTarefas")]
        //public ActionResult<List<UsuarioDTO>> Put(string tarefa, string novoNomeTarefa)
        //{
        //    return _usuarioService.EditarTarefa(tarefa, novoNomeTarefa);
        //}

        //[HttpDelete("DeletarTarefas")]
        //public ActionResult<List<UsuarioDTO>> Delete(string tarefa)
        //{
        //    return _usuarioService.DeletarTarefa(tarefa);
        //}
    }
}
