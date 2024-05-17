using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace NetCoreAppsettings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, builder) =>
                {
                    var memoryCollection = new Dictionary<string, string>
                    {
                        { "MainSettings:SubSetting", "This is the subsetting"}
                    };

                    var env = hostingContext.HostingEnvironment;
                    builder.Sources.Clear();

                    builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    builder.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    builder.AddJsonFile("custom.json", optional: true, reloadOnChange: true);
                    builder.AddXmlFile("custom.xml", optional: true, reloadOnChange: true);
                    builder.AddIniFile("custom.ini", optional: true, reloadOnChange: true);
                    builder.AddInMemoryCollection(memoryCollection);

                    if (hostingContext.HostingEnvironment.IsDevelopment())
                    {
                        builder.AddUserSecrets<Program>();
                    }
                    builder.AddEnvironmentVariables();
                    builder.AddCommandLine(args);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
