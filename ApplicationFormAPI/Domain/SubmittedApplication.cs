using ApplicationFormAPI.Common;

namespace ApplicationFormAPI.Domain
{
    public class SubmittedApplication : BaseEntity<string>
    {
        public string ApplicationFormId { get; set; }
        public List<SubmittedAnswer> Answers { get; set; }


        public SubmittedApplication(string applicationFormId, List<SubmittedAnswer> answers)
        {
            Id = Guid.NewGuid().ToString();
            ApplicationFormId = applicationFormId;
            Answers = answers;
            LastModifiedDate = DateTime.UtcNow;
            CreatedDate = DateTime.UtcNow;
            PartitionKey = Id;
        }

        public SubmittedApplication(string id, string applicationFormId, List<SubmittedAnswer> answers, DateTime lastModified)
        {
            Id = id;
            ApplicationFormId = applicationFormId;
            Answers = answers;
            LastModifiedDate = lastModified;
        }
    }
}
