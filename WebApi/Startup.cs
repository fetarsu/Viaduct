using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebApi.Startup))]

namespace WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}