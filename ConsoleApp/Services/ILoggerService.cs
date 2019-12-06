namespace ConsoleApp.Services
{
    public interface ILoggerService
    {
        void Create(string log);
        void Create(string titulo, string log);
    }
}