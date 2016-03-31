using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Apartment.Startup))]
namespace Apartment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
