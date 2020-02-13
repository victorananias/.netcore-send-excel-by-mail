using SendExcelByEmail.Services;
using SendExcelByEmail.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ClosedXML.Excel;

namespace SendExcelByEmail.Installers
{
    class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IXLWorkbook, XLWorkbook>();
            services.AddScoped<IExcelProductsService, ExcelProductsService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IMailService, MailService>();
        }
    }
}
