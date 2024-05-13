using ApplicationFormAPI.Domain;
using ApplicationFormAPI.Dtos;

namespace ApplicationFormAPI.Services.Interfaces
{
    public interface IApplicationFormService
    {
        Task<List<ApplicationFormDto>> GetAllApplicationFormsAsync();
        Task<ApplicationFormDto> GetApplicationFormAsync(string id);
        Task<bool> CreateApplicationFormAsync(ApplicationFormDto applicationForm);
        Task<(bool, string)> UpdateApplicationFormAsync(string id, ApplicationFormDto applicationForm);
        Task<(bool, string)> DeleteApplicationFormAsync(string id);
    }
}
