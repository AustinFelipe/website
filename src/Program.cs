using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace AustinSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string env = string.Empty;
            string port = string.Empty;
            
            foreach (var arg in args)
            {
                string[] parsed = arg.Split('=');
                
                if (parsed[0] == "ASPNETCORE_ENVIRONMENT")
                    env = parsed[1];
                else if (parsed[0] == "PORT")
                    port = parsed[1];
            }
            
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("credentials.json", optional: true)
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .Build();
                
            var host = new WebHostBuilder()
                .UseUrls(string.IsNullOrEmpty(port) ? config["ListenToUrl"] : $"http://0.0.0.0:{port}")
                .UseEnvironment(string.IsNullOrEmpty(env) ? config["Environment"] : env)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
