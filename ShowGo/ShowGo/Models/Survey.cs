using System.Collections.Generic;

namespace ShowGo.Models
{
    public class Survey
    {
        private List<MultipleChoiceQuestion> question;

        //[Key]
        public int SurveyId { get; set; }

        public string SurveyTitle { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<Choice> Choices { get; set; }



    }
}