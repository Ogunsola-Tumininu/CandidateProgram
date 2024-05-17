using System.ComponentModel.DataAnnotations;

namespace CandidateProgram.Models
{
    public class PersonalInfoField
    {

        public required Guid PersonalID { get; set; }
        
        public required Guid ProgramId { get; set; }
        
        public required string Firstname { get; set; }
        
        public required string Lastname { get; set; }
        public string Email { get; set; } = "";
        public string Nationality { get; set; } = "";

        public string CurrentResidence { get; set; } = "";

        public string IDNumber { get; set; } = "";
        public DateTime DateOfBirth { get; set; } = new DateTime();
        public string Gender { get; set; } = "";


    }
}
