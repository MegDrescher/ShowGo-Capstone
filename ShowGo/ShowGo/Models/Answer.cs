using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShowGo.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }

        [Column(TypeName= "VARCHAR")]
        [StringLength(50)]
        public int QuestionAnswer { get; set; } 
        
        public int QuestionId { get; set; } 

        public virtual Question Question { get; set; }

        //public virtual ApplicationUser AnsweredBy { get; set; }

        //public string AnsweredById { get; set; }

    }
}