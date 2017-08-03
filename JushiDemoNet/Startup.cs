using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JushiDemoNet.Startup))]
namespace JushiDemoNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
