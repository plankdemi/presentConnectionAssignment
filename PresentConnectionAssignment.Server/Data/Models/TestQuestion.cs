using System.ComponentModel.DataAnnotations;

namespace PresentConnectionAssignment.Server.Data.Models
{



    public class TestQuestion
    {

        [Required]

        [Key]
        public Guid QuestionId { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string QuestionType { get; set; }
        [Required]
        public List<string> PossibleQuestionAnswers { get; set; }
        [Required]
        public List<string> QuestionAnswer { get; set; }

    }
}
