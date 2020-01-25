using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ConsoleApp.Services
{
    public class ExampleService : IExampleService
    {
        public async Task Example(string content)
        {
            while (true)
            {
                Console.WriteLine(content);
                await Task.Delay(1000);
            }
        }
    }
}