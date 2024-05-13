using ApplicationFormAPI.Domain;
using ApplicationFormAPI.Dtos;
using ApplicationFormAPI.Infrastructure;
using ApplicationFormAPI.Infrastructure.Repositories;
using ApplicationFormAPI.Services.Interfaces;
using AutoMapper;

namespace ApplicationFormAPI.Services.Implementations
{
    public class SubmittedApplicationService : ISubmittedApplicationService
    {
        private readonly CosmosDbUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubmittedApplicationService(CosmosDbUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SubmittedApplicationDto> GetSubmittedApplicationByIdAsync(string id)
        {
            var submittedApplication = await _unitOfWork.SubmittedApplicationRepository.Get(id);
            if (submittedApplication == null)
            {
                return null;
            }
            return _mapper.Map<SubmittedApplicationDto>(submittedApplication);
        }

        public async Task<IEnumerable<SubmittedApplicationDto>> GetSubmittedApplicationsAsync()
        {
            var submittedApplications = await _unitOfWork.SubmittedApplicationRepository.GetAll();
            if (!submittedApplications.Any())
            {
                return null;
            }
            return _mapper.Map<IEnumerable<SubmittedApplicationDto>>(submittedApplications);
        }

        public async Task<bool> CreateSubmittedApplicationAsync(SubmittedApplicationDto submittedApplicationDto)
        {
            var submittedApplication = _mapper.Map<SubmittedApplication>(submittedApplicationDto);
            submittedApplication.Id = Guid.NewGuid().ToString();
            submittedApplication.PartitionKey = submittedApplication.Id;
            await _unitOfWork.SubmittedApplicationRepository.Create(submittedApplication);
            return true;
        }
    }
}
