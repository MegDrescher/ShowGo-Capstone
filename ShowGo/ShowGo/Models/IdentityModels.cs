using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ShowGo.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        internal readonly IEnumerable<object> Survey;

        public ApplicationDbContext()
            : base("ShowGo", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Concert> Concerts { get; set; }

         public DbSet<Answer> Answers { get; set; }
    

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Concertgoer> Concertgoers { get; set; }

        public DbSet<Genre> Genres { get; set; }

        //public DbSet<RecommendedResult> RecommendedResults { get; set; }


        public DbSet<Question> Questions { get; set; }

        public static object Question { get; internal set; }

    }
}