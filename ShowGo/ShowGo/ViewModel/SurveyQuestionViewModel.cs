using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShowGo.Models;

namespace ShowGo.ViewModels
{
    public class SurveyQuestionViewModel
    {   
        //public class SurveyViewModel
        //{
        //    //this.SurveyQuestions = new List<Question>();
           
        //}

        public int SurveyId { get; set; }
        public String SurveyTitle { get; set; }

        public IList<Question> SurveyQuestions { get; set; } 
            
    }

    public class SurveyResponseViewModel
    {
        public SurveyResponseViewModel()
        {
            this.SurveyQuestions = new List<Question>();
            this.QuestionAnswers = new List<Answer>();
        }

        public int SurveyId { get; set; }
        public string SurveyTitle { get; set; }
        public List<Question> SurveyQuestions { get; set; } 
        public List<Answer>  QuestionAnswers { get; set; }
    }
}