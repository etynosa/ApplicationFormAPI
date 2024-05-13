namespace ApplicationFormAPI.Dtos
{
    public class ApplicationFormDto
    {
        public ProgramInformationDto ProgramInformation { get; set; }
        public CandidatePersonalInformationDto CandidatePersonalInformation { get; set; }
        public List<CustomQuestionDto> CustomQuestions { get; set; }
    }
}
