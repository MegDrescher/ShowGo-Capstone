using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShowGo.Models;

namespace ShowGo.Web.Models.SurveyStorage
{
    public class SurveyStorage : IStorage<Survey>
    {
        private readonly ShowGoContext _context = new ShowGoContext();

        public void Create(Survey survey)
        {
            throw new NotImplementedException();
        }

        public Survey FirstOrDefault(Func<Survey, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public SurveyStorage FirstOrDefault()
        {
            return _context.Surveys.FirstOrDefault();
        }

        public Survey Find (int id)
        {
            return _context.Surveys.Find(id);
        }

        public IEnumerable<Survey> All()
        {
            throw new NotImplementedException();
        }
    }
}