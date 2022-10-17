using System.Linq.Expressions;

namespace IntermediateModels.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate = null);
        T GetById(Expression<Func<T, bool>> predicate);
        void Post(T entity);
        void Put(T entity);
        Task Delete(int id);
    }
}
