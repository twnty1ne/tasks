using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tasks.Buisness;

namespace Tasks.DAL
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {                         
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }
    }
}
