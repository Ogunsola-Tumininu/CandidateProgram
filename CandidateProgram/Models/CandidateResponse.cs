using System.ComponentModel.DataAnnotations;

namespace CandidateProgram.Models
{
    public class CandidateResponse
    {
        [Required]
        public Guid PersonalID { get; set; }
        [Required]
        public Guid ProgramId { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string Email { get; set; } = "";
        public string Nationality { get; set; } = "";

        public string CurrentResidence { get; set; } = "";

        public string IDNumber { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = "";
    }
}
