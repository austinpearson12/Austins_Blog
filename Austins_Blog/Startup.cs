using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Austins_Blog.Startup))]
namespace Austins_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
