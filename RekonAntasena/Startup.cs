using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RekonAntasena.Startup))]
namespace RekonAntasena
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}
