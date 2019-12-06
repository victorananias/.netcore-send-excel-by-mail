using System.IO;
using System;

namespace ConsoleApp.Services
{
    public class StorageService : IStorageService
    {
        public void Store(string fileName, string dir, string content)
        {
            try
            {
                var path2 = Path.Combine(new string[] {
                    Directory.GetCurrentDirectory(),
                    "storage",
                    dir
                });

                if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }

                using var fileStream = new StreamWriter(Path.Combine(path2, fileName));
                fileStream.Write(content);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}