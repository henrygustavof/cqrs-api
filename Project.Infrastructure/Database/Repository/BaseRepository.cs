using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Domain.Repository;
using Project.Infrastructure.Database.Utils;

namespace Project.Infrastructure.Database.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly Microsoft.EntityFrameworkCore.DbContext Context;

        protected BaseRepository(Microsoft.EntityFrameworkCore.DbContext context)
        {
            Context = context;
        }

        public async Task<TEntity> GetAsync(Guid id)
        {

            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public IEnumerable<TEntity> GetAll(int pageNumber, int pageSize,
                                           string sortBy, string sortDirection)
        {

            var skip = (pageNumber - 1) * pageSize;
            return Context.Set<TEntity>()
                .OrderBy(sortBy, sortDirection)
                .Skip(skip)
                .Take(pageSize);
        }

        public async Task<int> CountGetAllAsync()
        {
            return await Context.Set<TEntity>().CountAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);

        }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
    }
}
