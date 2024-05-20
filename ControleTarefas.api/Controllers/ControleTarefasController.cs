using ControleTarefas.Entity.DTO;
using ControleTarefas.Entity.Entities;
using ControleTarefas.Service.Interface.Services;
using ControleTarefas.WebApi;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ProjetoEstagioPitang.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControleTarefasController : ControllerBase
    {
        private static List<string> Tarefas { get; set; } = new() { "Tarefa0", "Tarefa1", "Tarefa2", "Tarefa3" };
        private readonly ILogger<ControleTarefasController> _logger;
        private readonly ITarefaService _tarefaService;

        public ControleTarefasController(ILogger<ControleTarefasController> logger, ITarefaService tarefaService)
        {
            _logger = logger;
            _tarefaService = tarefaService;
        }

        [HttpGet(Name = "BuscarTarefas")]
        public ActionResult<List<TarefaDTO>> ListarTodasTarefas()
        {
            return _tarefaService.ListarTodasTarefasDTO();
        }

        [HttpGet(Name = "FiltrarTarefas")]
        public ActionResult<List<TarefaDTO>> FiltrarTarefas(string tarefas)
        {
            return _tarefaService.ListarTarefasDTO(new List<string>() { tarefas });
        }

        [HttpPost(Name = "InserirTarefa")]
        public ActionResult<List<string>> Post(string tarefa)
        {
            if (Tarefas.Contains(tarefa))
            {
                _logger.LogInformation($"A tarefa {tarefa} ja` existe na lista de tarefas");
                throw new ServiceException($"A tarefa {tarefa} ja` existe na lista de tarefas");
            }

            Tarefas.Add(tarefa);
            _logger.LogInformation($"A tarefa {tarefa} foi inserida com sucesso!");

            return Tarefas;
        }

        [HttpPut(Name = "EditarTarefas")]
        public List<string> Put(string tarefa, string novoNomeTarefa)
        {
            if (Tarefas.IndexOf(tarefa) != -1)
            {
                Tarefas[Tarefas.IndexOf(tarefa)] = novoNomeTarefa;
                _logger.LogInformation($"A tarefa {tarefa} foi editada para {novoNomeTarefa}");
            }
            else
                throw new ServiceException($"A tarefa {tarefa} nao existe na lista de tarefas", ex);
            
            return Tarefas;
        }

        [HttpDelete(Name = "ExcluirTarefas")]
        public List<string> Delete(string tarefa)
        {
            if (Tarefas.IndexOf(tarefa) != -1)
            {
                Tarefas.RemoveAt(Tarefas.IndexOf(tarefa));
                _logger.LogInformation($"A tarefa {tarefa} foi deletada com sucesso");
            }
            else
                throw new ServiceException($"A tarefa {tarefa} nao existe na lista de tarefas", ex);

            return Tarefas;
        }
    }
}
