using System;
using System.Threading.Tasks;
using ConsoleApp.Services;
using ConsoleApp.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ConsoleApp
{
    public class Startup
    {
        private IExampleService _service;
        public Startup(
            IExampleService service,
            IOptions<AppSettings> settings
        )
        {
            _service = service;
        }

        public async Task Run()
        {
           await  _service.Example("Hello World");
        }
    }
}