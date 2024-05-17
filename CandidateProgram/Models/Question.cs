using System.ComponentModel.DataAnnotations;

namespace CandidateProgram.Models
{
    public class Question
    {
        
        public required Guid QuestionID { get; set; }

        public required Guid ProgramId { get; set; }
        
        public required string Type { get; set; }

        public string Description { get; set; }

        public List<string> Choices { get; set; } = [];

        public int MaxChoice { get; set; } = new int();
    }
}
