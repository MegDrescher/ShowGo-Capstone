using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowGo.Models
{
    public class RecommendedResult
    {
        [Key]

        public int ResultsId { get; set; }

        public object Question { get; set; }
        public int QuestionId { get; set; }

        [ForeignKey("Choice")]
        public int ChoiceId { get; set; }
        public Choice Choice { get; set; }

        [ForeignKey("Concertgoer")]
        public int ConcertgoerId { get; set; }
        public Concertgoer Concertgoer { get; set; }

    }
}