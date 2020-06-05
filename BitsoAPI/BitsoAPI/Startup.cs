using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BitsoAPI.Startup))]
namespace BitsoAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
