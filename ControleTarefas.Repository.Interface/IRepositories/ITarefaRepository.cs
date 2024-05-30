using ControleTarefas.Entity.DTO;
using ControleTarefas.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Repository.Interface.IRepositories
{
    public interface ITarefaRepository
    {
        void Deletar(Tarefa tarefa);
        void Editar(string tarefa, string novoNomeTarefa);
        void Inserir(Tarefa tarefa);
        List<TarefaDTO> ListarTarefasDTO(List<string> tarefas);
        List<TarefaDTO> ListarTodasTarefasDTO();
        Tarefa ObterTarefa(string tituloTarefa);
    }
}
