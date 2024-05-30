using ControleTarefas.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Service.Interface.Services
{
    public interface ITarefaService
    {
        List<TarefaDTO> DeletarTarefa(string tarefa);
        List<TarefaDTO> EditarTarefa(string tarefa, string novoNomeTarefa);
        List<TarefaDTO> InserirTarefa(string tarefa);
        List<TarefaDTO> ListarTarefasDTO(List<string> tarefas);
    }
}
