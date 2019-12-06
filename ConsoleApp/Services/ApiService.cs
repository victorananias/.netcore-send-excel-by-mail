using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ConsoleApp.Services
{
    public class ApiService : IApiService
    {
        public class Response
        {
        }

        private readonly IConfiguration _configuration;

        public ApiService(IConfiguration configuration)
        {
            _configuration = configuration.GetSection("App");
        }

        public async Task<Response> Post(object content)
        {
            try
            {
                var url = _configuration["url"];

                var json = JsonConvert.SerializeObject(content);

                using HttpClient http = new HttpClient { BaseAddress = new Uri(url) };

                var responseMessage = await http.PostAsync("", new StringContent(json, Encoding.UTF8, "application/json"));

                var response = await responseMessage.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Response>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}