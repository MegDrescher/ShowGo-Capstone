using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ShowGo.Models;

[assembly: OwinStartupAttribute(typeof(ShowGo.Startup))]
namespace ShowGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
        }

        private void CreateRoles()
        {
            ApplicationDbContext database = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(database));

            if (!roleManager.RoleExists("Artist"))
            {
                var role = new IdentityRole
                {
                    Name = "Artist"
                };
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Concertgoer"))
            {
                var role = new IdentityRole
                {
                    Name = "Concergoer"
                };
                roleManager.Create(role);
            }

        }
    }
}
