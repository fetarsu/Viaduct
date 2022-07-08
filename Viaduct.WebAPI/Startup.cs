using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Viaduct.WebAPI.Startup))]

namespace Viaduct.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}