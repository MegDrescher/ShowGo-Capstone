using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowGo.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }

        public int QuestionAnswer { get; set; } 
        
        public int QuestionId { get; set; } 

        public virtual Question Question { get; set; }

        public virtual ApplicationUser AnsweredBy { get; set; }

        public string AnsweredById { get; set; }

    }
}