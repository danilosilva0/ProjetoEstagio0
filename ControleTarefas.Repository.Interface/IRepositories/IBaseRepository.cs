using ControleTarefas.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Repository.Interface.IRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> ObterPorId(object id);
        Task<List<TEntity>> Todos();
        Task<TEntity> Inserir(TEntity entity);
        Task<TEntity> Atualizar(TEntity entity);
        Task Deletar(TEntity entity);
        Task DeletarPorId(object id);
    }
}
