using ApplicationFormAPI.Common;
using ApplicationFormAPI.Infrastructure.IRepositories;
using Microsoft.Azure.Cosmos;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Linq.Expressions;

namespace ApplicationFormAPI.Infrastructure.Repositories
{
    public class CosmosDbGenericRepository<T> : ICosmosDbRepository<T> where T : BaseEntity<string>
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Microsoft.Azure.Cosmos.Container _container;

        public CosmosDbGenericRepository(CosmosClient cosmosClient, string databaseId, string containerId)
        {
            _cosmosClient = cosmosClient;
            _container = _cosmosClient.GetContainer(databaseId, containerId);
        }
        public async Task<int> Count(Expression<Func<T, bool>> expression)
        {
            var count = _container.GetItemLinqQueryable<T>(true).Where(expression).Count();
            return count;
        }

        public async Task Create(T entity)
        {
            entity.Id ??= Guid.NewGuid().ToString();
            await _container.CreateItemAsync(entity, new PartitionKey(entity.PartitionKey));
        }

        public async Task Create(List<T> entity)
        {
            entity.ForEach(async c => await Create(c));
        }

        public async Task<int> Delete(T entity)
        {
            await _container.DeleteItemAsync<T>(entity.Id, new PartitionKey(entity.PartitionKey));
            return (0);
        }

        public async Task<T> Get(string id, string partitionKey)
        {
            return await _container.ReadItemAsync<T>(id, new PartitionKey(partitionKey));
        }
        public async Task<T> Get(string id)
        {
            return await _container.ReadItemAsync<T>(id, new PartitionKey(id));
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            return _container.GetItemLinqQueryable<T>(true).Where(expression).AsEnumerable().FirstOrDefault();
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return _container.GetItemLinqQueryable<T>(true, null).ToList().AsQueryable();
        }

        public async Task<IQueryable<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return _container.GetItemLinqQueryable<T>(true, null).Where(expression).AsQueryable();
        }
        public async Task<IEnumerable<T>> GetMultipleAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<T>(new QueryDefinition(queryString));
            var results = new List<T>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter, Func<T, object> orderBy)
        {
            var items = _container.GetItemLinqQueryable<T>(true, null).Where(filter).ToList();
            return items.OrderBy(orderBy).ToList();
        }

        public async Task UpdateEntity(T entity)
        {
            await _container.ReplaceItemAsync(entity, entity.Id, new PartitionKey(entity.PartitionKey));
        }
    }
}
