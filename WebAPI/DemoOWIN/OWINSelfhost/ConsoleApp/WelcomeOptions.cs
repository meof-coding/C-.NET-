using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class WelcomeOptions
    {
        public string HostName { get; set; }
        public string Welcome { get; set; }

        public WelcomeOptions(string hostName, string welcome)
        {
            HostName = hostName;
            Welcome = welcome;
        }
    }
}
