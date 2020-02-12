using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SendExcelMail.Installers
{
    interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
