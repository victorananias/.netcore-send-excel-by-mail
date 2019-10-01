using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp
{
    class Program
    {
        private static IConfiguration _configuration;
        static void Main(string[] args)
        {
            LoadConfiguration();
            
            Console.WriteLine("conn: " + _configuration.GetConnectionString("DefaultConnection"));
        }

        private static void LoadConfiguration()
        {
            _configuration = (new ConfigurationBuilder())
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
        }
    }
}
