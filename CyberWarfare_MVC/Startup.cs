using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CyberWarfare_MVC.Startup))]
namespace CyberWarfare_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
