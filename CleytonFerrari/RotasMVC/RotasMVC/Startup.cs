using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RotasMVC.Startup))]
namespace RotasMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
