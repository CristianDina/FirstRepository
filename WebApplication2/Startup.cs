using BusinessLogic;
using DataAccess;
using Microsoft.Owin;
using Owin;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using WebApplication2.Controllers;

[assembly: OwinStartupAttribute(typeof(WebApplication2.Startup))]
namespace WebApplication2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        { 
            ConfigureAuth(app);
        }
    }
}
