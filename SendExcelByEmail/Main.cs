using System.Net.Mime;
using System.Threading.Tasks;
using SendExcelByEmail.Services;
using SendExcelByEmail.Settings;
using Microsoft.Extensions.Options;

namespace SendExcelByEmail
{
    public class Main
    {
        private IProductsService _productsService;
        private IExcelProductsService _excelProductsService;
        private IMailService _mailService;

        public Main(
            IOptions<AppSettings> settings, 
            IProductsService productsService, 
            IExcelProductsService excelProductsService, IMailService mailService)
        {
            _productsService = productsService;
            _excelProductsService = excelProductsService;
            _mailService = mailService;
        }

        public async Task Run()
        {
            var products = _productsService.GetProducts(15);
            var excel = await _excelProductsService.Get(products);
            
            _mailService
                .From("example@mail.com.br")
                .To("example2@mail.com.br")
                .AddAttachment(excel, new ContentType("application/vnd.ms-excel"))
                .Send("teste", "esse é o email", false);
        }
    }
}