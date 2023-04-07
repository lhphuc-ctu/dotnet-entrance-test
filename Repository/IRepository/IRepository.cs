using System.Linq.Expressions;

namespace dotnet_entrance_test.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
        void AddAsync(T entity);
        void Remove(T entity);
    }
}
