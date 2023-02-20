using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasks.Buisness;

namespace Tasks.DAL
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate);
        void DeleteRange(IEnumerable<TEntity> entities);
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
