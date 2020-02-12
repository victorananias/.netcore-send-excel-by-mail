using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SendExcelMail.Models;

namespace SendExcelMail.Services
{
    public interface IExcelProductsService
    {
        Task<MemoryStream> Get(IEnumerable<Product> products);
    }
}