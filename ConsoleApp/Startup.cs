using System;
using System.Threading.Tasks;
using ConsoleApp.Services;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp
{
    public class Startup
    {
        private IExampleService _service;
        public Startup(
            IExampleService service
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