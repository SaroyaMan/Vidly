using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly_New.Startup))]
namespace Vidly_New
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
