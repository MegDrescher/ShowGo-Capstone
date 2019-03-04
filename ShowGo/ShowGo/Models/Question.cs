using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShowGo.Models
{
    public class Question
    {
        internal int Id;

        [Key]
        public int QuestionId { get; set; }
        
        public string Body { get; set; }
        public string SurveyQuestion { get; set; }

        public QuestionType Type { get; set; }

        public int SurveyId { get; set; }
       
        public virtual Survey Survey { get; set; }

        public virtual List<Answer> Answers { get; set; }
       
    }   
}
