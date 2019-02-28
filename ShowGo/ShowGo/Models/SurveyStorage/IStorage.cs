using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowGo.Models.SurveyStorage
{
    public class IStorage<T>
    {
        void Create(T entity);
        T FirstOrDefault(Func<T, bool> predicate);
        T FirstOrDefault();
        T Find(int id);
        IEnumerable<T> All();
    }
}