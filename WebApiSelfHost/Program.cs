using System;
using Microsoft.Owin.Hosting;

namespace OwinWebApiSelfHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string url = "http://localhost:38081/";
            var startOpts = new StartOptions(url)
            {
            };
            using (WebApp.Start<Startup>(startOpts))
            {
                Console.WriteLine("Server run at " + url + " , press Enter to exit.");
                Console.ReadLine();
            }
        }
    }
}
