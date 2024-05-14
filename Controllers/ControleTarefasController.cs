using ControleTarefas.Entity.DTO;
using ControleTarefas.Service.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ProjetoEstagioPitang.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControleTarefasController : ControllerBase
    {

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
            return _tarefaService.ListarTarefasDTO(null);
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
                //TODO: Exceptions 
            }

            Tarefas.Add(tarefa);
            _logger.LogInformation($"A tarefa {tarefa} foi inserida com sucesso!");

            return Tarefas;
        }

        [HttpPut(Name = "EditarTarefas")]
        public List<string> Put(string tarefa, string novoNomeTarefa)
        {
            if (!Tarefas.Contains(tarefa))
            {
                _logger.LogInformation($"A tarefa {tarefa} nao existe na lista de tarefas");
            }

            if (Tarefas.IndexOf(tarefa) != -1)
                Tarefas[Tarefas.IndexOf(tarefa)] = novoNomeTarefa;

            _logger.LogInformation($"A tarefa {tarefa} foi editada para {novoNomeTarefa}");

            return Tarefas;
        }

        [HttpDelete(Name = "ExcluirTarefas")]
        public List<string> Delete(string tarefa)
        {
            if (!Tarefas.Contains(tarefa))
            {
                _logger.LogInformation($"A tarefa {tarefa} nao existe na lista de tarefas");
            }

            if (Tarefas.IndexOf(tarefa) != -1)
                Tarefas.RemoveAt(Tarefas.IndexOf(tarefa));

            return Tarefas;
        }
    }
}
