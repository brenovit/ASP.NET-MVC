using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Validacoes.Startup))]
namespace Validacoes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
