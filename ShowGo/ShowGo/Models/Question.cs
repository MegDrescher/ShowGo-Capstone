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

        public int SurveyId { get; set; }

        //public virtual ICollection<Choice> Choices { get; set; }

        public virtual Survey Survey { get; set; }

        public virtual List<Answer> Answers { get; set; }
        public int Id { get; internal set; }

        public Question()
        {
            List<Answer> Answers = new List<Answer>();
        }

    }   
}
