using ControleTarefas.Entity.DTO;
using ControleTarefas.Entity.Entities;
using ControleTarefas.Repository.Interface.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Repository.Repositories
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(Contexto contexto) : base(contexto) { }

        public Task<List<TarefaDTO>> ListarTarefasDTO(List<string> tarefas)
        {
            var query = EntitySet
                .Where(tarefa => tarefas.Contains(tarefa.Titulo.ToUpper()))
                .Select(tarefa => new TarefaDTO
                {
                    Titulo = tarefa.Titulo,
                })
                .OrderBy(tarefa => tarefa.Titulo)
                .Distinct();
            return query.ToListAsync();
        }

        public void Editar(string tarefa, string novoNomeTarefa)
        {
            throw new NotImplementedException();
        }

        public Task<List<TarefaDTO>> ListarTodasTarefasDTO()
        {
            var query = EntitySet
                .Select(tarefa => new TarefaDTO
                {
                    Titulo = tarefa.Titulo,
                })
                .OrderBy(e => e.Titulo)
                .Distinct();
            return query.ToListAsync();
        }

        public Task<Tarefa> ObterTarefa(string tituloTarefa, bool asNoTracking = false)
        {
            var query = EntitySet.AsQueryable();
            if(asNoTracking) query = query.AsNoTracking();
            return query.FirstOrDefaultAsync(e => e.Titulo.ToLower() == tituloTarefa.ToLower());
        }
    }
}
