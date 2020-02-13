using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using SendExcelByEmail.Models;

namespace SendExcelByEmail.Services
{
    public class ProductsService : IProductsService
    {
        public IEnumerable<Product> GetProducts(int quantity)
        {
            for (var i = 0; i < quantity; i++)
            {
                yield return new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Product " + i.ToString("0000"),
                    Price = RandomNumberGenerator.GetInt32(1, 100) +
                            (decimal) RandomNumberGenerator.GetInt32(1, 10) / 10
                };
            }
        }
    }
}