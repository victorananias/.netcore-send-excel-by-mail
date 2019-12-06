namespace ConsoleApp.Services
{
    public interface IStorageService
    {
        void Store(string fileName, string dir, string content);
    }
}