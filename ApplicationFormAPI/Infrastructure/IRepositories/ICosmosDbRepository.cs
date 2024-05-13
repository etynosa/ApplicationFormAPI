using System.Linq.Expressions;

namespace ApplicationFormAPI.Infrastructure.IRepositories
{
    public interface ICosmosDbRepository<T> where T : class
    {
        // Write 
        Task Create(T entity);
        Task Create(List<T> entity);
        Task UpdateEntity(T entity);

        Task<IEnumerable<T>> GetMultipleAsync(string queryString);
        Task<IQueryable<T>> GetAll();
        Task<IQueryable<T>> GetAll(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetAll(
                Expression<Func<T, bool>> filter,
                 Func<T, object> orderBy);
        Task<T> Get(string id, string partitionKey);
        Task<T> Get(string id);
        Task<T> Get(Expression<Func<T, bool>> expression);

        Task<int> Count(Expression<Func<T, bool>> expression);

        // Delete 
        Task<int> Delete(T entity);
    }
}
