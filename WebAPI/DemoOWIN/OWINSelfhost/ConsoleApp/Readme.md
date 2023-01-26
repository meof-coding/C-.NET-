
# OWIN Self Hosting Console App

 A step by step of how to create this project:
 * Create a __Console App (.NET Framework)__ project, and give a name `Owin.SelfHosting.Console` . Use an equivalent project template if using a different version of Visual Studio.
 * Add a reference to the nuget package `Microsoft.Owin.SelfHost`, which will add following references to the project.
    * `Owin`
    * `Microsoft.Owin`
    * `Microsoft.Owin.Diagnostic`
    * `Microsoft.Owin.Hosting`
    * `Microsoft.Owin.Host.HttpListener`
    * `Microsoft.Owin.Host.SelfHost`
 * Create a `WelcomeOptions` class in a separate file. This class is used later in the `WelcomeMiddleware` class

 ``` c#
 namespace Owin.SelfHosting.Console
{
   internal class WelcomeOption
   {
      public string HostName { get; set; }
      public string Welcome { get; set; }

      public WelcomeOption(string hostName, string welcome)
      {
         HostName = hostName;
         Welcome = welcome;
      }
   }
}
```
 * Add a `WelcomeMiddleware` class in a separate file. This class is used later in the `AppBuilderExtension ` class

 ``` c#
using System;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace Owin.SelfHosting.Console
{
   internal class WelcomeMiddleware : OwinMiddleware
   {
      private readonly WelcomeOption _option;

      public WelcomeMiddleware(OwinMiddleware next, WelcomeOption option) : base(next)
      {
         _option = option;
      }

      public override async Task Invoke(IOwinContext context)
      {
         System.Console.WriteLine
                ("Http request received at " + DateTime.UtcNow.ToString());
         await Next.Invoke(context);
         string welcome = string.Format("I am {0}. {1}{2}", 
                          _option.HostName, _option.Welcome, Environment.NewLine);
         await context.Response.WriteAsync(welcome).ConfigureAwait(false);
      }
   }
}
```
* Create an `AppBuilderExtensions` class in a separate file. This class contains extension methods which allow developers to register the `WelcomeMiddleware` using the `UseWelcome` method instead of the generic Use method. The first method takes no argument and calls the second method by passing a default value.
``` c#
namespace Owin.SelfHosting.Console
{
   internal static class AppBuilderExtensions
   {
      public static IAppBuilder UseWelcome(this IAppBuilder appBuilder)
      {
         return appBuilder.UseWelcome(new WelcomeOption("Peter", "Welcome to this site"));
      }

      public static IAppBuilder UseWelcome
             (this IAppBuilder appBuilder, WelcomeOption option)
      {
         return appBuilder
           .Use(typeof(WelcomeMiddleware), option);
      }
   }
}
```
* Create a `Startup` class in a separate file. This class is required when creating a listener
```c#
namespace Owin.SelfHosting.Console
{
   internal class Startup
   {
      public void Configuration(IAppBuilder appBuilder)
      {
         appBuilder
           .UseWelcome();
      }
   }
}
```
* In the `Program` class, put the code below:
```c#
using Microsoft.Owin.Hosting;

namespace Owin.SelfHosting.Console
{
   internal class Program
   {
      public static void Main(string[] args)
      {
         string hostUrl = "http://localhost:9000/console";
         using (WebApp.Start<Startup>(""))
         {
            System.Console.WriteLine
                   (string.Format("Start Listening at {0} ...", hostUrl));
            System.Console.ReadKey();
         }
      }
   }
}
```
* Run the application, and wait until it displays `'Start Listening at http://localhost:9000/console ...'`
* To test the application, run any browsers and type `'http://localhost:9000/console'`
* The browser should display `'I am Peter. Welcome to this site'` and the console application should display `'Http request received at [request timestamp]'`
