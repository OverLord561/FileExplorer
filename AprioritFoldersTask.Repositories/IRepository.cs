using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AprioritFoldersTask.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        Task<int> AddAsync(TEntity entity);
        int AddRange(IEnumerable<TEntity> entities);
        Task<int> AddRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        int Remove(TEntity entity);
        Task<int> RemoveAsync(TEntity entity);
        int RemoveRange(IEnumerable<TEntity> entities);

    }
}
