using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieCat_HTML2.Startup))]
namespace MovieCat_HTML2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
