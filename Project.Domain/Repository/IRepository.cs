using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(Guid id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        IEnumerable<TEntity> GetAll(int pageNumber, int pageSize,
            string sortBy, string sortDirection);

        Task<int> CountGetAllAsync();

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
