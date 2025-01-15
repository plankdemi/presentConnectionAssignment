using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PresentConnectionAssignment.Server.Data.Models
{
    public class Testee
    {
     
        [Required]
        [Key]
        public string Email { get; set; }

        [Required]
        public int Score { get; set; }


        public DateTime Date { get; set;}


    }
}
