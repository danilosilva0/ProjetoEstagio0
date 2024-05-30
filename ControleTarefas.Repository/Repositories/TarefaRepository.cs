using ControleTarefas.Entity.DTO;
using ControleTarefas.Entity.Entities;
using ControleTarefas.Repository.Interface.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Repository.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private static List<Tarefa> Tarefas { set; get; } = new() { new("Tarefa1"), new("Tarefa2"), new("Tarefa3"), new("Tarefa4")};

        public void Deletar(Tarefa tarefa)
        {
            Tarefas.Remove(tarefa);
        }

        public void Editar(string tarefa, string novoNomeTarefa)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Tarefa tarefa)
        {
            Tarefas.Add(tarefa);
        }

        public List<TarefaDTO> ListarTarefasDTO(List<string> tarefas)
        {
            return Tarefas.Where(tarefa => tarefas.Contains(tarefa.Titulo.ToUpper()))
                .OrderBy(tarefa => tarefa.Titulo)
                .Distinct()
                .Select(tarefa => new TarefaDTO
                {
                    Titulo = tarefa.Titulo
                })
                .ToList();
        }

        public List<TarefaDTO> ListarTodasTarefasDTO()
        {
            return Tarefas.OrderBy(tarefa => tarefa.Titulo)
                .Distinct()
                .Select(tarefa => new TarefaDTO
                {
                    Titulo = tarefa.Titulo
                })
                .ToList();
        }

        public Tarefa ObterTarefa(string tituloTarefa)
        {
            return Tarefas.FirstOrDefault(e => e.Titulo.ToLower() == tituloTarefa.ToLower());
        }
    }
}
