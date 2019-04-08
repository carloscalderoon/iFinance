using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iFinance.Startup))]
namespace iFinance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
