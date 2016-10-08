using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoCalendario.Startup))]
namespace ProyectoCalendario
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
