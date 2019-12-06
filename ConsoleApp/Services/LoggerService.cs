using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly string _logsDirectory;
        private readonly string _logFile;

        public LoggerService(IConfiguration _config)
        {
            _logsDirectory = string.IsNullOrEmpty(_config.GetSection("Logger")["Path"]) ? "./logs" : _config.GetSection("Logger")["Path"];
            _logFile = _logsDirectory + "/" + DateTime.Now.ToString("yyyyMMdd");
        }

        public void Create(string log)
        {
            CheckLogsDirectory();

            Console.WriteLine(log);

            Insert(log);
        }

        public void Create(string titulo, string log)
        {
            CheckLogsDirectory();

            Console.WriteLine(titulo);
            Console.WriteLine(log);

            Insert(log, titulo);
        }

        private void Insert(string log, string titulo = "")
        {
            using StreamWriter fileStream = new StreamWriter(_logFile, true);

            fileStream.WriteLine("\n--- " + titulo + " " + DateTime.Now.ToString("HH:mm:ss") + " ---");
            fileStream.WriteLine(log);
            fileStream.Close();
        }

        private void CheckLogsDirectory()
        {
            if (!Directory.Exists(_logsDirectory))
            {
                Directory.CreateDirectory(_logsDirectory);
            }
        }
    }
}