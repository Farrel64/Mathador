using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mathador.Startup))]
namespace Mathador
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
