using ApplicationFormAPI.Domain;
using AutoMapper;

namespace ApplicationFormAPI.Dtos.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApplicationForm, ApplicationFormDto>()
                .ForMember(dest => dest.ProgramInformation, opt => opt.MapFrom(src => src.ProgramInformation))
                .ForMember(dest => dest.CandidatePersonalInformation, opt => opt.MapFrom(src => src.CandidatePersonalInformation))
                .ForMember(dest => dest.CustomQuestions, opt => opt.MapFrom(src => src.CustomQuestions))
                .ReverseMap();
            CreateMap<ProgramInformation, ProgramInformationDto>().ReverseMap();
            CreateMap<CandidatePersonalInformation, CandidatePersonalInformationDto>().ReverseMap();
            CreateMap<CustomQuestion, CustomQuestionDto>()
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options))
                .ReverseMap();
            CreateMap<Option, OptionDto>().ReverseMap();
            CreateMap<SubmittedAnswer, SubmittedAnswersDto>().ReverseMap();
            CreateMap<SubmittedApplication, SubmittedApplicationDto>()
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers))
                .ReverseMap();

        }
    }
}
