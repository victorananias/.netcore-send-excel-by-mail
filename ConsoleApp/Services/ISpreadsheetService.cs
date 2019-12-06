using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Services
{
    public interface ISpreadsheetService
    {
        ISheet Read(string filePath, int sheetIndex = 0);
    }
}
