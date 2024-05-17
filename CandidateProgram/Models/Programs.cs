namespace CandidateProgram.Models
{
    public class Programs
    {
        public required Guid ProgramId { get; set; }
        public required string ProgramName { get; set; }

        public string ProgramDescription { get; set; } = "";

        public PersonalInfoField PersonalInformationField { get; set;  }// = new PersonalInfoField();

        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
