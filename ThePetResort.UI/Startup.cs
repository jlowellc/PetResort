using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThePetResort.UI.Startup))]
namespace ThePetResort.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
