using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace OwinApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string url = "http://localhost:38080/";
            var startOpts = new StartOptions(url)
            {
            };
            using (WebApp.Start<Startup>(startOpts))
            {
                Console.WriteLine($"Server run at {url} , press Enter to exit.");
                Console.ReadLine();
            }
        }
    }
}
