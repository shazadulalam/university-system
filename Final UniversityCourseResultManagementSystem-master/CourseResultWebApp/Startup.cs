using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourseResultWebApp.Startup))]
namespace CourseResultWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
