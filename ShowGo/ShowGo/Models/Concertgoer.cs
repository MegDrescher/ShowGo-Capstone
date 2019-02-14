using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowGo.Models
{
    public class Concertgoer
    {
        [Key]
        public int ConcertgoerId { get; set; }

        [Display(Name = "First Name")]

        public string FirstName;
        [Display(Name = "Last Name")]
        public string LastName;

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}