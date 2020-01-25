using System;
using System.Threading.Tasks;


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