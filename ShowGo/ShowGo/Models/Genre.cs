using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShowGo.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string Title { get; set; }

    }
}