using ApplicationFormAPI.Common;
using ApplicationFormAPI.Common.Enums;

namespace ApplicationFormAPI.Domain
{
    public class CustomQuestion : BaseEntity<string>
    {
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public List<Option>? Options { get; set; }

        //public CustomQuestion( string text, QuestionType questionType, List<Option> options) {
        
        //    Id = Guid.NewGuid().ToString();
        //    Text = text;
        //    Type = questionType;
        //    Options = options;
        //    LastModifiedDate = DateTime.UtcNow;
        //    CreatedDate = DateTime.UtcNow;
        //    PartitionKey = Id;
        //}

        //public CustomQuestion(string id, string text, QuestionType questionType, List<Option> options, DateTime lastModified)
        //{
        //    Id = id;
        //    Text = text;
        //    Type = questionType;
        //    Options = options;
        //    LastModifiedDate = lastModified;
        //}
    }

}
