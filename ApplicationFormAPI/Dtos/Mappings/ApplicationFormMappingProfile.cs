using ApplicationFormAPI.Domain;
using AutoMapper;

namespace ApplicationFormAPI.Dtos.Mappings
{
    public class ApplicationFormMappingProfile : Profile
    {
        public ApplicationFormMappingProfile()
        {
            CreateMap<ApplicationFormDto, ApplicationForm>()
            .ConstructUsing(dto => new ApplicationForm(
                MapProgramInformation(dto.ProgramInformation),
                MapCandidatePersonalInformation(dto.CandidatePersonalInformation),
                MapCustomQuestions(dto.CustomQuestions)
            )).ReverseMap();
            ;
        }

        private ProgramInformation MapProgramInformation(ProgramInformationDto dto)
        {
            // Create a new ProgramInformation object from the DTO
            return new ProgramInformation
            {
               ProgramTitle = dto.ProgramTitle,
               ProgramDescription = dto.ProgramDescription
            };
        }

        private CandidatePersonalInformation MapCandidatePersonalInformation(CandidatePersonalInformationDto dto)
        {
            // Create a new CandidatePersonalInformation object from the DTO
            return new CandidatePersonalInformation
            {
               FirstName = dto.FirstName,
               LastName = dto.LastName,
               Email = dto.Email,
               Phone = dto.Phone,
               Nationality = dto.Nationality,
               Residence = dto.Residence,
               Id = dto.Id,
               DateOfBirth = dto.DateOfBirth,
               Gender = dto.Gender,
            };
        }

        private List<CustomQuestion> MapCustomQuestions(List<CustomQuestionDto> dtos)
        {
            // Map each CustomQuestionDto to a CustomQuestion object
            return dtos.Select(dto => new CustomQuestion
            {
                Text = dto.Text,
                Type = dto.Type,
                Options = dto.Options.Select(option => new Option()
                {
                    Value = option.Value
                }).ToList()
            }).ToList();
        }
    }
}
