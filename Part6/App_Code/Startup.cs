using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Part6.Startup))]
namespace Part6
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
