using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShowGo.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string Text { get; set; }

        //[Display(Name ="")]
        //[Required]
        //public string questionLabel { get; set; }
        //[Display(Name ="")]
        //[Required]
        //public string choiceA { get; set; }
        //[Display(Name = "")]
        //[Required]
        //public string choiceB { get; set; } 
        //[Display(Name ="")]
        //[Required]
        //public string choiceC { get; set; }
        //[Display(Name ="")]
        //[Required]
        //public string choiceD { get; set; } 
        //[Display(Name = "")]
        //[Required]
        //public string answer { get; set; }


        public bool IsCorrect(string answer)
        {
            return String.Compare(answer, answer, true) == 0;
        }

        public List<RecommendedResult> RecommendedResults { get; set; }

    }
}