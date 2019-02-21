using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowGo.Models
{

    public class Choice
    {
        [Key]
        public int ChoiceId { get; set; }
        public string Text { get; set; }
        public virtual Question Question { get; set; }

       

    }

    public class MultipleChoiceQuestion
    {
        public string question;

        //list of possible answers to the question
        public string[] choices;

        private int answer;

       
        public MultipleChoiceQuestion()
        {
            choices = new string[5];
        }

        //gets and sets the question 
        public string Question { get => question; set => question = value; }

        //gets the indexed question as a string 

        public string GetChoices(int index) => choices[index];

        //set the choice at the correct index
        public void SetChoice(int index, string value) => choices[index] = value;

        // Gets and sets the correct answer as an index
        public int Answer { get => answer; set => answer = value; }



    }
}





