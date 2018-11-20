using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OPW.Startup))]
namespace OPW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
