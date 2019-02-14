using System.ComponentModel.DataAnnotations;

namespace ShowGo.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string Title { get; set; }

    }
}