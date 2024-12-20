﻿using System.Linq.Expressions;

namespace RepositoryPattern.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(Guid id);
        Task<bool> Add(T entity);
        Task<bool> Delete(Guid entity);
        Task<bool> Upsert(T entity);

        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> pridicate);
    }
}
