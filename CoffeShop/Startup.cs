using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoffeShop.Startup))]
namespace CoffeShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
