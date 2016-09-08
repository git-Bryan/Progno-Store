using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Progno.Web.Startup))]
namespace Progno.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
