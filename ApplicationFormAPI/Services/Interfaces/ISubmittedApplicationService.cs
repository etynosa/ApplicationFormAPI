using ApplicationFormAPI.Dtos;

namespace ApplicationFormAPI.Services.Interfaces
{
    public interface ISubmittedApplicationService
    {
        Task<IEnumerable<SubmittedApplicationDto>> GetSubmittedApplicationsAsync();
        Task<bool> CreateSubmittedApplicationAsync(SubmittedApplicationDto submittedApplicationDto);
        Task<SubmittedApplicationDto> GetSubmittedApplicationByIdAsync(string id);
    }
}
