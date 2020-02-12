using System.Collections.Generic;
using SendExcelMail.Models;

namespace SendExcelMail.Services
{
    public interface IProductsService
    {
        IEnumerable<Product> GetProducts(int quantity);
    }
}