using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cwtechdbWebRole.Startup))]
namespace cwtechdbWebRole
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
