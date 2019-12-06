using ConsoleApp.Services;
using ConsoleApp.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Installers
{
    class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILoggerService, LoggerService>();
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<IApiService, ApiService>();
            services.AddScoped<ISpreadsheetService, SpreadsheetService>();

            var mail = configuration.Get<AppSettings>().Mail;

            services.AddSingleton<IMailService>(new MailService(mail.Host, mail.Port, mail.Username, mail.Password));
        }
    }
}
