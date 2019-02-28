using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowGo.Web.Models.SurveyStorage
{
    public class QuestionsStorage : IStorage<Question>
    {
        private readonly ShowGoContext_context = new ShowGoContext();
        public void Create (Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }

        public Question FirstOrDefault(Func<Question, bool> predicate)
        {
            return _context.Questions.FirstOrDefault(predicate);
        }

        public Question FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public Question Find(int id)
        {
            return _context.Questions.Find(id);
        }

        public IEnumerable<Question> All()
        {
            return _context.Questions.ToList();
        }
    }
  
}