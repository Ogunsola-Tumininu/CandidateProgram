using System.ComponentModel.DataAnnotations;

namespace CandidateProgram.Models
{
    public class Answers
    {
        
        public required Guid AnswerID { get; set; }

        public required Guid QuestionID { get; set; }

        public required Guid ResponseID { get; set; }

        public string Response { get; set; }
    }
}
