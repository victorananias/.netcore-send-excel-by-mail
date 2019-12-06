using System;
using System.IO;
using ConsoleApp.Installers;
using ConsoleApp.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();

            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<Startup>().Run();
        }

        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            var configuration = Configuration();

            Console.WriteLine(configuration.GetConnectionString("DefaultConnection"));

            services.AddSingleton<IConfiguration>(configuration);

            services.InstallServicesAssembly(configuration);

            services.AddTransient<Startup>();

            services.AddOptions();

            services.Configure<AppSettings>(configuration);

            return services;
        }

        private static IConfiguration Configuration()
        {
            return (new ConfigurationBuilder())
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
        }
    }
}
