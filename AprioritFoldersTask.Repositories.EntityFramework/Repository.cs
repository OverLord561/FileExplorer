using AprioritFoldersTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AprioritFoldersTask.Repositories.EntityFramework
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, new()
    {
        protected readonly ApplicationDbContext _context;

        protected Repository()
        {

        }
        public Repository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public virtual async Task<int> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<TEntity>().Add(entity);
            return await _context.SaveChangesAsync();
        }

        protected virtual IQueryable<TEntity> Include()
        {
            return _context.Set<TEntity>();
        }

        public virtual int AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            return _context.SaveChanges();
        }

        public virtual async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            return await _context.SaveChangesAsync();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Include()
                .Where(predicate)
                .ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Include()
                .Where(predicate)
                .ToListAsync();
        }
        public virtual int Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges();
        }

        public virtual async Task<int> RemoveAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync();
        }


        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Include().SingleOrDefaultAsync(predicate);
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var originalValues = _context.Set<TEntity>().Find(entity);
            if (originalValues != null)
            {
                _context.Entry(originalValues).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException(nameof(entity));
            }
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var originalValues = await _context.Set<TEntity>().FindAsync(entity);
            if (originalValues != null)
            {
                _context.Entry(originalValues).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(entity));
            }
        }

        public virtual int RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            return _context.SaveChanges();
        }
    }
}
