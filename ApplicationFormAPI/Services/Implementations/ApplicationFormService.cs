using ApplicationFormAPI.Domain;
using ApplicationFormAPI.Dtos;
using ApplicationFormAPI.Infrastructure;
using ApplicationFormAPI.Services.Interfaces;
using AutoMapper;

namespace ApplicationFormAPI.Services.Implementations
{
    public class ApplicationFormService : IApplicationFormService
    {
        private readonly CosmosDbUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApplicationFormService(CosmosDbUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateApplicationFormAsync(ApplicationFormDto applicationForm)
        {
           var mappedApplicationForm = _mapper.Map<ApplicationForm>(applicationForm);
            mappedApplicationForm.Id = Guid.NewGuid().ToString();
            await _unitOfWork.ApplicationFormRepository.Create(mappedApplicationForm);
            return true;
        } 
        
        public async Task<ApplicationFormDto> GetApplicationFormAsync(string id)
        {
            var result = await _unitOfWork.ApplicationFormRepository.Get(id);
            if (result == null)
            {
                return null;
            }
            return _mapper.Map<ApplicationFormDto>(result);
        }

        public async Task<List<ApplicationFormDto>> GetAllApplicationFormsAsync()
        {
            var result = await _unitOfWork.ApplicationFormRepository.GetAll();
            if (!result.Any())
            {
                return null;
            }
            return _mapper.Map<List<ApplicationFormDto>>(result);
        }

        public async Task<(bool, string)> UpdateApplicationFormAsync(string id, ApplicationFormDto applicationForm)
        {
            bool isExist = await _unitOfWork.ApplicationFormRepository.Get(id) != null;
            if (!isExist)
            {
                return (false, "Application form not found");
            }
            var mappedApplicationForm = _mapper.Map<ApplicationForm>(applicationForm);
            mappedApplicationForm.Id = id;
            await _unitOfWork.ApplicationFormRepository.UpdateEntity(mappedApplicationForm);
            return (true, "Application form updated successfully");
        }

        public async Task<(bool, string)> DeleteApplicationFormAsync(string id)
        {
            var applicationForm = await _unitOfWork.ApplicationFormRepository.Get(id);
            if (applicationForm == null)
            {
                return (false, "Application form not found");
            }
            await _unitOfWork.ApplicationFormRepository.Delete(applicationForm);
            return (true, "Application form deleted successfully");
        }

    }
}
