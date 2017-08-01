using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReviewSiteProject1.Startup))]
namespace ReviewSiteProject1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
