using System.Linq.Expressions;
using TaskMaster.Core.Interfaces;

namespace TaskMaster.Persistence.Data.Context;

public interface IMongoContext<T>
    where T : IModel
{
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, CancellationToken cancellationToken = default(CancellationToken));
    Task<T> GetAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default(CancellationToken));
    Task CreateAsync(T document, CancellationToken cancellationToken = default(CancellationToken));
    Task UpdateAsync(T document, CancellationToken cancellationToken = default(CancellationToken));
    Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken));
    Task DeleteAllAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default(CancellationToken));
    Task<int> CountAsync(CancellationToken cancellationToken = default(CancellationToken));
}
