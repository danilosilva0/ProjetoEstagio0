using ControleTarefas.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleTarefas.Entity.Entities;
using ControleTarefas.Repository.Interface.IRepositories;

namespace ControleTarefas.Repository.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly Contexto _contexto;
        protected virtual DbSet<TEntity> EntitySet { get; }

        public BaseRepository(Contexto contexto)
        {
            _contexto = contexto;
            EntitySet = _contexto.Set<TEntity>();
        }
        public async Task<TEntity> Atualizar(TEntity entidade)
        {
            var entityEntry = EntitySet.Update(entidade);

            await _contexto.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task Deletar(TEntity entidade)
        {
            EntitySet.Remove(entidade);

            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarPorId(object id)
        {
            var entity = await EntitySet.FindAsync(id);

            if (entity != null)
                await Deletar(entity);
        }

        public async Task<TEntity> Inserir(TEntity entidade)
        {
            var entityEntry = await EntitySet.AddAsync(entidade);

            await _contexto.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<TEntity> ObterPorId(object id)
        {
            return await EntitySet.FindAsync(id);
        }

        public Task<List<TEntity>> Todos() => EntitySet.ToListAsync();
    }
}
