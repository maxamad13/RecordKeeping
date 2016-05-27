using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecordKeeping.Startup))]
namespace RecordKeeping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
