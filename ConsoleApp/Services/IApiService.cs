using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public interface IApiService
    {
        Task<ApiService.Response> Post(object content);
    }
}