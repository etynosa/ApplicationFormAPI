using ApplicationFormAPI.Domain;
using ApplicationFormAPI.Infrastructure._DI;
using ApplicationFormAPI.Infrastructure.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace ApplicationFormAPI.Infrastructure
{
    public class CosmosDbUnitOfWork : IDisposable
    {
        private readonly CosmosClient _cosmosClient;
        private readonly string _databaseId;

        public CosmosDbUnitOfWork(CosmosClient cosmosClient, IOptions<CosmosConfig> cosmosOptions)
        {
            _cosmosClient = cosmosClient;
            _databaseId = cosmosOptions.Value.DatabaseId;
        }

        private CosmosDbGenericRepository<CustomQuestion> _customQuestionRepository;
        private CosmosDbGenericRepository<ApplicationForm> _applicationFormRepository;
        private CosmosDbGenericRepository<SubmittedApplication> _submittedApplicationRepository;
        public CosmosDbGenericRepository<CustomQuestion> CustomQuestionRepository
        {
            get
            {
                if (_customQuestionRepository == null)
                {
                    _customQuestionRepository = new CosmosDbGenericRepository<CustomQuestion>(_cosmosClient, _databaseId, nameof(CustomQuestion).ToString());
                }
                return _customQuestionRepository;
            }
        }  
        
        public CosmosDbGenericRepository<ApplicationForm> ApplicationFormRepository
        {
            get
            {
                if (_applicationFormRepository == null)
                {
                    _applicationFormRepository = new CosmosDbGenericRepository<ApplicationForm>(_cosmosClient, _databaseId, nameof(ApplicationForm).ToString());
                }
                return _applicationFormRepository;
            }
        }

        public CosmosDbGenericRepository<SubmittedApplication> SubmittedApplicationRepository

        {
            get
            {
                if (_submittedApplicationRepository == null)
                {
                    _submittedApplicationRepository = new CosmosDbGenericRepository<SubmittedApplication>(_cosmosClient, _databaseId, nameof(SubmittedApplication).ToString());
                }
                return _submittedApplicationRepository;
            }
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _cosmosClient.Dispose();
                }
            }
            disposed = true;
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
