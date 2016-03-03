using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CinemaCounter.Startup))]
namespace CinemaCounter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
