using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using ShowGo.Models;
using ShowGo.Models.SurveyStorage;
using Context = System.Runtime.Remoting.Contexts.Context;

namespace ShowGo.Web.Models.SurveyStorage
{
    public class QuestionsStorage : IStorage<Question>
    {
        private readonly ShowGoContext_context = new ShowGoContext();
        public void Create (Question question)
        {
            Context.Questions.Add(question);
            Context.SaveChanges();
        }

        public Question FirstOrDefault(Func<Question, bool> predicate)
        {
            return Content.Questions.FirstOrDefault(predicate);
        }

        public Question FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public Question Find(int id)
        {
            return DbContext.Questions.Find(id);
        }

        public IEnumerable<Question> All()
        {
            return DbContext.Questions.ToList();
        }
    }
  
}