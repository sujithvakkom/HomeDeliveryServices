using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeDelivery.Startup))]
namespace HomeDelivery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
