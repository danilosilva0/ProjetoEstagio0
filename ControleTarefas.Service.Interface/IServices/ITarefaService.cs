using ControleTarefas.Entity.DTO;
using ControleTarefas.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Service.Interface.Services
{
    public interface ITarefaService
    {
        Task<List<TarefaDTO>> DeletarTarefa(string tarefa);
        Task<List<TarefaDTO>> EditarTarefa(string tarefa, string novoNomeTarefa);
        Task<List<TarefaDTO>> InserirTarefa(CadastroTarefaModel tarefa);
        Task<List<TarefaDTO>> ListarTarefasDTO(List<string> tarefas);
    }
}
