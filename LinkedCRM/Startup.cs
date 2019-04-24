using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LinkedCRM.Startup))]
namespace LinkedCRM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
