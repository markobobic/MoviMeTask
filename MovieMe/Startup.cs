using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieMe.Startup))]
namespace MovieMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
