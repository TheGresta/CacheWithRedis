using System.Linq.Expressions;
using Core.Entity;
using Core.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Repositories;

public interface IAsyncRepository<T> : IQuery<T> where T : BaseEntity
{
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate,
                      Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                      bool enableTracking = true,
                      CancellationToken cancellationToken = default);

    Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                    int index = 0, int size = 10, bool enableTracking = true,
                                    CancellationToken cancellationToken = default);

    Task<T> AddAsync(T entity, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
    Task<T> UpdateAsync(T entity, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
    Task<T> DeleteAsync(T entity, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
}