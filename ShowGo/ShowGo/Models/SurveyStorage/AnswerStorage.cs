using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using ShowGo.Models;
using ShowGo.Models.SurveyStorage;

namespace ShowGo.Web.Models.SurveyStorage
{
    public class AnswerStorage : IStorage<Answer>
    {

        public void Create(Answer answer)
        {
            context.Answers.Add(answer);
            Context.SaveChanges();
        }

        public Answer FirstOrDefault(Func<Answer, bool> predicate)
        {
            return DbContext.Answers.FirstOrDefault(predicate);
        }

        public Answer FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public Answer Find(int id)
        {
            return context.Answers.Find(id);
        }

        public IEnumerable<Answer> All()
        {
            return context.Answers.ToList();
        }
    }
 
}