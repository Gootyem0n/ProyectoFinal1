using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoFinal1.Startup))]
namespace ProyectoFinal1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
