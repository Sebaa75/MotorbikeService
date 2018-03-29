using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MotorbikeService.Startup))]
namespace MotorbikeService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
