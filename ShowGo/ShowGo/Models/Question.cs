using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShowGo.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string text { get; set;}

    }   
}
