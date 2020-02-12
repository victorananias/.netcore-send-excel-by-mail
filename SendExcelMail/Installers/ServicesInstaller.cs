using SendExcelMail.Services;
using SendExcelMail.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SendExcelMail.Installers
{
    class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IExcelProductsService, ExcelProductsService>();
        }
    }
}
