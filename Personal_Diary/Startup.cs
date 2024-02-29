using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Personal_Diary.Startup))]
namespace Personal_Diary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
