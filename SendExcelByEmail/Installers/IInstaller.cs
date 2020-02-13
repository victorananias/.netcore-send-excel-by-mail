using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SendExcelByEmail.Installers
{
    interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
