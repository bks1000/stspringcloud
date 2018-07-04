using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Service_Authority
{
    public class Program
    {
        public static string IP = "localhost";
        public const int Port = 6101;
        public const string ServiceName = "service-authority";
        public const string Version = "v1";

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls($"http://*:{Program.Port}")
                .UseStartup<Startup>()
                .Build();
    }
}
