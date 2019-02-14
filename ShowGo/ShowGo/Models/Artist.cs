using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShowGo.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [Display(Name = "First Name")]

        public string FirstName;
        [Display(Name = "Last Name")]
        public string LastName;

        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}