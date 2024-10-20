using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLib.Util.Services
{
    public interface IFileLoaderService
    {
        Task<string> LoadFile(string filePath);
        Task<T> LoadFileAndDeSerialize<T>(string filePath);
        Task SaveObjectToFile<T>(string filePath, T obj);
        Task SaveStringToFile(string filePath, string content);
    }
}
