namespace ApplicationFormAPI.Dtos
{
    public class SubmittedAnswersDto
    {
        public string QuestionId { get; set; }
        public object Answer { get; set; }
    }
    public class SubmittedApplicationDto
    {
        public string ApplicationFormId { get; set; }
        public List<SubmittedAnswersDto> Answers { get; set; }
    }
}
