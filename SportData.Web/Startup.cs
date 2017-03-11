using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SportData.Web.Startup))]
namespace SportData.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
