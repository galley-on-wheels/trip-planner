using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tripper.Startup))]
namespace Tripper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
