﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowGo.Models
{
    public class Choice
    {
        [Key]
        public int ChoiceId { get; set; }
        public string Text { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public class MultipleChoiceQuestion
        {
            public List<string> Choices { get; private set; }

            public int CorrectAnswer { get; set; }

            public MultipleChoiceQuestion()
            {
                Choices = new List<string>();
            }
        }
    }
}