using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShowGo.Models
{
    public class Question
    {
    

        [Key]
        public int QuestionId { get; set; }

        public string SurveyQuestion { get; set; }
   
        public virtual ICollection<Choice> Choices { get; set; }

        public string text { get; set; }

        public virtual Survey Survey { get; set; } 

      
    }   
}
