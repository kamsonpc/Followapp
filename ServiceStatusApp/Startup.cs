using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiceStatusApp.Startup))]
namespace ServiceStatusApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
