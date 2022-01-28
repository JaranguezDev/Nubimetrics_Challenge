using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nubimetrics_ChallengeCurrencies.Services.Helpers
{
    public static class FileProcessor
    {
        public async static Task<bool> SaveToFile(string data, string path, string fileName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(path) ||
                    string.IsNullOrWhiteSpace(data) ||
                    string.IsNullOrWhiteSpace(fileName))
                    return false;

                if(!File.Exists(path))
                    Directory.CreateDirectory(path);

                var fullPath = Path.Combine(path, fileName);

                await File.WriteAllTextAsync(fullPath, data);
            }
            catch (UnauthorizedAccessException unEx)
            {
                throw unEx;
            }
            catch (IOException ioEx)
            {
                throw ioEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }
    }
}
