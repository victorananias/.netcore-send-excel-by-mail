using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ClosedXML.Excel;
using SendExcelMail.Models;

namespace SendExcelMail.Services
{
    public class ExcelProductsService : IExcelProductsService
    {
        private readonly XLWorkbook _workbook;

        public ExcelProductsService(XLWorkbook workbook)
        {
            _workbook = workbook;
        }

        public async Task<MemoryStream> Get(IEnumerable<Product> products)
        {
            var ws = _workbook.Worksheets.Add("Products");
            
            ws.Cell("A1").Value = "Id";
            ws.Cell("B1").Value = "Name";
            ws.Cell("C1").Value = "Price";
            ws.Range("C2:C20").Style.NumberFormat.NumberFormatId = 2;

            var rngHeaders = ws.Range("A1:C1");
            rngHeaders.Style.Font.Bold = true;

            var i = 2;
            foreach (var product in products)
            {
                Console.WriteLine(product.Price.ToString("0.00"));
                ws.Cell($"A{i}").Value = product.Id;
                ws.Cell($"B{i}").Value = product.Name;
                ws.Cell($"C{i}").Value = product.Price.ToString("0.00");
                i++;
            }
            
            ws.Columns(1, 3).AdjustToContents();

            await using var memoryStream = new MemoryStream();
            
            _workbook.SaveAs(memoryStream);

            return memoryStream;
        }
    }
}