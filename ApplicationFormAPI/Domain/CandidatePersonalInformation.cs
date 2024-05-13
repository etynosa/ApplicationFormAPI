namespace ApplicationFormAPI.Domain
{
    public class CandidatePersonalInformation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string Residence { get; set; }
        public string Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        //public CandidatePersonalInformation(string firstName, string lastName, string email, string phone, string nationality,
        //    string residence, DateTime dateOfBirth, string gender)
        //{
        //    Id = Guid.NewGuid().ToString();
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Email = email;
        //    Phone = phone;
        //    Nationality = nationality;
        //    Residence = residence;
        //    DateOfBirth = dateOfBirth;
        //    Gender = gender;
        //}

        //public CandidatePersonalInformation(string firstName, string lastName, string email, string phone, string nationality,
        //    string residence, string id, DateTime dateOfBirth, string gender)
        //{
        //    Id = id;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Email = email;
        //    Phone = phone;
        //    Nationality = nationality;
        //    Residence = residence;
        //    DateOfBirth = dateOfBirth;
        //    Gender = gender;
        //}

    }
}
