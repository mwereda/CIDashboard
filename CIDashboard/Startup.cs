using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CIDashboard.Startup))]
namespace CIDashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
