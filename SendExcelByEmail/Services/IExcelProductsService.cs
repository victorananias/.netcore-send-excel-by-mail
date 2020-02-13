using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SendExcelByEmail.Models;

namespace SendExcelByEmail.Services
{
    public interface IExcelProductsService
    {
        Task<MemoryStream> Get(IEnumerable<Product> products);
    }
}