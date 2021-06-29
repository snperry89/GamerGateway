using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GamerGateway.Startup))]
namespace GamerGateway
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
