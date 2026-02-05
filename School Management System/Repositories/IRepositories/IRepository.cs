using System.Linq.Expressions;

namespace School_Management_System.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<T>> GetAsync(
           Expression<Func<T, bool>>? filter = null,
           string? includeProperties = null,
           bool tracking = false,
           CancellationToken cancellationToken = default,
           object includes = null);

        Task<T?> GetOneAsync(
         Expression<Func<T, bool>>? filter = null,
         bool tracking = false,
         CancellationToken cancellationToken = default,
         params Expression<Func<T, object>>[] includes
     );
        Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
           int pageNumber,
           int pageSize,
           Expression<Func<T, bool>>? filter = null,
           string? includeProperties = null,
           bool tracking = false,
           CancellationToken cancellationToken = default);

        Task DeleteAllEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
