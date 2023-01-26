using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class AppBuilderExtensions
    {
        //extension method for IAppBuilder by passing this appbuilder   
        public static IAppBuilder UseWelcome(this IAppBuilder appBuilder)
        {
            return appBuilder.UseWelcome(new WelcomeOptions("Peter", "Welcome to this site"));
        }

        public static IAppBuilder UseWelcome
               (this IAppBuilder appBuilder, WelcomeOptions option)
        {
            return appBuilder
              .Use(typeof(WelcomeMiddleware), option);
        }
    }
}
