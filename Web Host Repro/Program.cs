using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Web_Host_Repro
{
    public static class Program
    {
        public static Task Main()
        {
            return new HostBuilder()
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder
                        .ConfigureServices(services =>
                        {
                            // System.IO.FileNotFoundException:
                            // 'Could not load file or assembly 'Very_Important_App, Culture=neutral, PublicKeyToken=null'.
                            // The system cannot find the file specified.'
                            services.AddControllers();
                        });
                })
                .ConfigureHostConfiguration(cfg =>
                {
                    cfg.AddCommandLine(new[] { "--ApplicationName=Very_Important_App" });
                })
                .Build()
                .RunAsync();
        }
    }
}
