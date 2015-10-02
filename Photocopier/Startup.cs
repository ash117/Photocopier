using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Photocopier.Startup))]
namespace Photocopier
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
