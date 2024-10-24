using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Core.IRepositories;
using RepositoryPattern.Data;
using System.Linq.Expressions;

namespace RepositoryPattern.Core.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected AppDbContext _context;
        internal DbSet<T> dbSet;
        public readonly ILogger _logger;

        public GenericRepository(
            AppDbContext context,
            ILogger logger)
        {
            _context = context;
             dbSet = context.Set<T>();
            _logger = logger;
        }

        public async Task<bool> Add(T entity)
        {
           await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }

        public virtual Task<bool> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<T>> Find(Expression<Func<T, bool>> pridicate)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }

        public  virtual Task<bool> Delete(Guid entity)
        {
            throw new NotImplementedException();
        }
    }
    
}
