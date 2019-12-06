using System;
using System.IO;
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

            services.AddSingleton<IConfiguration>(configuration);

            services.AddTransient<Startup>();

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
