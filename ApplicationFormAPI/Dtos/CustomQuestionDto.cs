using ApplicationFormAPI.Common.Enums;

namespace ApplicationFormAPI.Dtos
{
    public class CustomQuestionDto
    {
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public List<OptionDto> Options { get; set; }
    }
}
