using System.ComponentModel.DataAnnotations;

namespace PresentConnectionAssignment.Server.Data.Models
{
    public class TestGrader
    {
        [Key]
        [Required]
        public string UserEmail { get; set; }

        public Dictionary<string, List<string>> FormData { get; set; }

    }
}
