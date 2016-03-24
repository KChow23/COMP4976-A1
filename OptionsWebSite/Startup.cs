using Microsoft.Owin;
using Owin;

[assembly: OwinStartup("OptionsWebSite", typeof(OptionsWebSite.Startup))]
namespace OptionsWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
