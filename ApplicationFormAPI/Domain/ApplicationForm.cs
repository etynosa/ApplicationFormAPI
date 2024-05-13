using ApplicationFormAPI.Common;

namespace ApplicationFormAPI.Domain
{
    public class ApplicationForm : BaseEntity<string>
    {
        public ProgramInformation ProgramInformation { get; set; }
        public CandidatePersonalInformation CandidatePersonalInformation { get; set; }
        public List<CustomQuestion> CustomQuestions { get; set; }

        public ApplicationForm(ProgramInformation programInformation, CandidatePersonalInformation candidatePersonalInformation, List<CustomQuestion> customQuestions)
        {
            Id = Guid.NewGuid().ToString();
            ProgramInformation = programInformation;
            CandidatePersonalInformation = candidatePersonalInformation;
            CustomQuestions = customQuestions;
            LastModifiedDate = DateTime.UtcNow;
            CreatedDate = DateTime.UtcNow;
            PartitionKey = Id;
        }

        public ApplicationForm(string id, ProgramInformation programInformation, CandidatePersonalInformation candidatePersonalInformation, List<CustomQuestion> customQuestions, DateTime lastModified)
        {
            Id = id;
            ProgramInformation = programInformation;
            CandidatePersonalInformation = candidatePersonalInformation;
            CustomQuestions = customQuestions;
            LastModifiedDate = lastModified;
        }
    }
}
