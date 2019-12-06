using System.IO;
using ConsoleApp.Services;
using NPOI.OpenXml4Net.OPC;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace ConsoleApp.Services
{
    public class SpreadsheetService: ISpreadsheetService
    {   
        public ISheet Read (string filePath, int sheetIndex = 0)
        {

            XSSFWorkbook wb;
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                OPCPackage pkg = OPCPackage.Open(file);
                wb = new XSSFWorkbook(pkg);
                
            }
            
            string firstSheet = wb.GetSheetName(sheetIndex);

            ISheet sheet = wb.GetSheet(firstSheet);

            return sheet;
        }
    }
}