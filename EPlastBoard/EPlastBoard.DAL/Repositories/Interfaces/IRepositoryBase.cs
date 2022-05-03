using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace EPlastBoard.DAL.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task CreateAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Attach(T entity);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Func<IQueryable<T>, IQueryable<T>> sorting = null);

        Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
