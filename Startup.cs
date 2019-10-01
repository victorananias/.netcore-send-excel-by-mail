using System;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Run()
        {
        }
    }
}