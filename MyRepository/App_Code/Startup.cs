using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyRepository.Startup))]
namespace MyRepository
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
