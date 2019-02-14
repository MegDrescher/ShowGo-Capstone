using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShowGo.Startup))]
namespace ShowGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
