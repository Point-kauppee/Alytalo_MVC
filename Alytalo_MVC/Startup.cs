using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Alytalo_MVC.Startup))]
namespace Alytalo_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
