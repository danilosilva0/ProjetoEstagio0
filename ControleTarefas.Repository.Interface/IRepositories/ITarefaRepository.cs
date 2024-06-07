using ControleTarefas.Entity.DTO;
using ControleTarefas.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Repository.Interface.IRepositories
{
    public interface ITarefaRepository : IBaseRepository<Tarefa>
    {
        //void Deletar(Tarefa tarefa);
        //void Editar(string tarefa, string novoNomeTarefa);
        //void Inserir(Tarefa tarefa);
        Task<List<TarefaDTO>> ListarTarefasDTO(List<string> tarefas);
        Task<List<TarefaDTO>> ListarTodasTarefasDTO();
        Task<Tarefa> ObterTarefa(string tituloTarefa, bool asNoTracking = false);
    }
}
