using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FeriasFacil.Startup))]
namespace FeriasFacil
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
