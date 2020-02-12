using System.Threading.Tasks;
using SendExcelMail.Services;
using SendExcelMail.Settings;
using Microsoft.Extensions.Options;

namespace SendExcelMail
{
    public class Main
    {
        private IProductsService _productsService;
        private ExcelProductsService _excelProductsService;

        public Main(
            IOptions<AppSettings> settings, 
            IProductsService productsService, 
            ExcelProductsService excelProductsService
        )
        {
            _productsService = productsService;
            _excelProductsService = excelProductsService;
        }

        public async Task Run()
        {
            // var products = _productsService.GetProducts(15);
            // var excel = await _excelProductsService.Get(products);
            
            
        }
    }
}