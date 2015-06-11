using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApplication37.Startup))]
namespace WebApplication37
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
