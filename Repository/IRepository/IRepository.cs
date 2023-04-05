using System.Linq.Expressions;

namespace dotnet_entrance_test.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        bool Any(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
    }
}
