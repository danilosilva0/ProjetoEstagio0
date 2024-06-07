using ControleTarefas.Entity.DTO;
using ControleTarefas.Entity.Entities;
using ControleTarefas.Entity.Model;
using ControleTarefas.Service.Interface.Services;
using ControleTarefas.WebApi;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ControleTarefas.Helper;

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
        public async Task<List<TarefaDTO>> ListarTodasTarefas()
        {
            return await _tarefaService.ListarTarefasDTO(null);
        }

        [HttpGet("FiltrarTarefas")]
        public async Task<List<TarefaDTO>> FiltrarTarefas(string tarefas)
        {
            return await _tarefaService.ListarTarefasDTO(new List<string>() { tarefas });
        }

        [HttpPost("InserirTarefa")]
        [TransacaoObrigatoria]
        public async Task<List<TarefaDTO>> Post(CadastroTarefaModel tarefa)
        {
            return await _tarefaService.InserirTarefa(tarefa);
        }

        [HttpPut("EditarTarefas")]
        [TransacaoObrigatoria]
        public async Task<List<TarefaDTO>> Put(string tarefa, string novoNomeTarefa)
        {
            return await _tarefaService.EditarTarefa(tarefa, novoNomeTarefa);
        }

        [HttpDelete("DeletarTarefas")]
        [TransacaoObrigatoria]
        public async Task<List<TarefaDTO>> Delete(string tarefa)
        {
            return await _tarefaService.DeletarTarefa(tarefa);
        }
    }
}
