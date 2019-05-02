using System.Collections.Generic;

namespace ShowGo.Models
{
    public class Survey
    {
        internal ApplicationUser CreatedBy;


        //[Key]
        public int SurveyId { get; set; }

        public string SurveyTitle { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public int Id { get; internal set; }
        public string Title { get; internal set; }
        //public List<Question> Questions { get; internal set; }

        //public virtual ICollection<Choice> Choices { get; set; }

        public Survey()
        {
           
        }
    }

   
}