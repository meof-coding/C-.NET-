using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string hostUrl = "http://localhost:9000/console";
            using (WebApp.Start<Startup>(hostUrl))
            {
                System.Console.WriteLine
                       (string.Format("Start Listening at {0} ...", hostUrl));
                System.Console.ReadKey();
            }
        }
    }
}
