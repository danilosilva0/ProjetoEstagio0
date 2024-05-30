using ControleTarefas.Entity.DTO;
using ControleTarefas.Entity.Entities;
using ControleTarefas.Service.Interface.Services;
using ControleTarefas.WebApi;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ProjetoEstagioPitang.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControleTarefasController : ControllerBase
    {
        private static List<string> Tarefas { get; set; } = new() { "Tarefa0", "Tarefa1", "Tarefa2", "Tarefa3" };
        private readonly ITarefaService _tarefaService;

        public ControleTarefasController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet("BuscarTarefas")]
        public ActionResult<List<TarefaDTO>> ListarTodasTarefas()
        {
            return _tarefaService.ListarTarefasDTO(null);
        }

        [HttpGet("FiltrarTarefas")]
        public ActionResult<List<TarefaDTO>> FiltrarTarefas(string tarefas)
        {
            return _tarefaService.ListarTarefasDTO(new List<string>() { tarefas });
        }

        [HttpPost("InserirTarefa")]
        public ActionResult<List<TarefaDTO>> Post(string tarefa)
        {
            return _tarefaService.InserirTarefa(tarefa);
        }

        [HttpPut("EditarTarefas")]
        public ActionResult<List<TarefaDTO>> Put(string tarefa, string novoNomeTarefa)
        {
            return _tarefaService.EditarTarefa(tarefa, novoNomeTarefa);
        }

        [HttpDelete("DeletarTarefas")]
        public ActionResult<List<TarefaDTO>> Delete(string tarefa)
        {
            return _tarefaService.DeletarTarefa(tarefa);
        }
    }
}
