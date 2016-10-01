using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoveIt.WebUi.Startup))]
namespace MoveIt.WebUi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
