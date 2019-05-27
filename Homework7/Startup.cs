using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Homework7.Startup))]
namespace Homework7
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
