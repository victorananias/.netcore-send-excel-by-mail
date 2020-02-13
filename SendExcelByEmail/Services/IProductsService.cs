using System.Collections.Generic;
using SendExcelByEmail.Models;

namespace SendExcelByEmail.Services
{
    public interface IProductsService
    {
        IEnumerable<Product> GetProducts(int quantity);
    }
}