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


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Concert> Concerts { get; set; }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Concertgoer> Concertgoers { get; set; }

        public DbSet<RecommendedResult> RecommendedResults { get; set; }


        public DbSet<Question> Questions { get; set; }

        public DbSet<Choice> Choices { get; set; }
        public static object Question { get; internal set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<RecommendedResult>()
        //    .HasRequired(x => x.Question)
        //    .WithMany()
        //    .HasForeignKey(x => x.QuestionId)
        //    .WillCascadeOnDelete(false);

        //    base.OnModelCreating(modelBuilder);
        //}

    }
}