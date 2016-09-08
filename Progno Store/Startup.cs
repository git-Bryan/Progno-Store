using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Progno_Store.Startup))]
namespace Progno_Store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
