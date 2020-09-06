using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(da.Startup))]
namespace da
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
