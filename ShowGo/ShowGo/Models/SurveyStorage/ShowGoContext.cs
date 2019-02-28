using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShowGo.Models
{
    public class ShowGoContext : ApplicationDbContext
    {
        public ShowGoContext()
            :base("DefaultConnection")
        {

        }

        public new DbSet<Survey> Surveys { get; set; }
        public new DbSet<Question> Questions { get; set; }

        public new DbSet<Answer> Answers { get; set; }
    }
}