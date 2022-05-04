using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace EPlastBoard.DAL.Repositories.Realization
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected EPlastBoardDBContext EPlastDBContext { get; set; }

        public RepositoryBase(EPlastBoardDBContext ePlastDBContext)
        {
            this.EPlastDBContext = ePlastDBContext;
        }

        public async Task CreateAsync(T entity)
        {
            await this.EPlastDBContext.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            this.EPlastDBContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.EPlastDBContext.Set<T>().Remove(entity);
        }

        public void Update(IEnumerable<T> entity)
        {
            foreach (var item in entity)
            {
                this.EPlastDBContext.Set<T>().Update(item);
            }
        }

        public void Attach(T entity)
        {
            this.EPlastDBContext.Set<T>().Attach(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Func<IQueryable<T>, IQueryable<T>> sorting = null)
        {
            return await this.GetQuery(predicate, include, sorting).ToListAsync();
        }

        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var query = this.GetQuery(predicate, include);
            return await query.FirstAsync();
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return await this.GetQuery(predicate, include).FirstOrDefaultAsync();
        }

        private IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Func<IQueryable<T>, IQueryable<T>> sorting = null)
        {
            var query = this.EPlastDBContext.Set<T>().AsNoTracking();
            if (include != null)
            {
                query = include(query);
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (sorting != null)
            {
                query = sorting(query);
            }
            return query;
        }
    }
}

