using System;
using System.IO;
using System.Threading.Tasks;
using SendExcelByEmail.Installers;
using SendExcelByEmail.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SendExcelByEmail
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            await serviceProvider.GetService<Main>().Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            var configuration = Configuration();

            services.AddSingleton(configuration);

            services.InstallServicesAssembly(configuration);

            services.AddTransient<Main>();

            services.AddOptions();
            
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

            return services;
        }

        private static IConfiguration Configuration()
        {
            try
            {
                return new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", false, true)
                    .Build();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
                return null;
            }
        }
    }
}