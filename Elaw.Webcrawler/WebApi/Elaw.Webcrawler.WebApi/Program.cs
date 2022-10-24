using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;

namespace Elaw.Webcrawler.WebApi
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var isService = Helpers.ConfigurationHelper.getConfigValue("ElawConfig:RunAs").Trim().ToLower().Equals("service");

            if (isService)
            {
                CreateHostBuilder(args).Build().Run();
            }
            else
            {
                var builder = CreateWebHostBuilder(args.Where(arg => arg != "--console").ToArray());
                builder.UseUrls(Helpers.ConfigurationHelper.getConfigValue("ElawConfig:SystemUrl"));
                var host = builder.Build();
                host.Run();

            }

        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.Configure<EventLogSettings>(config =>
                    {
                        config.LogName = "Elaw API Service";
                        config.SourceName = "Elaw API Service Source";
                    });
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureWebHost(config =>
                {
                    config.UseUrls(Helpers.ConfigurationHelper.getConfigValue("ElawConfig:SystemUrl"));
                }).UseWindowsService();
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();


    }
}
