using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibrarySystem.Web.Startup))]
namespace LibrarySystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
