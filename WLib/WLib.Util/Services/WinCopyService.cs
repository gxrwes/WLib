using System;
using System.IO;
using System.Threading.Tasks;

namespace WLib.Util.Services
{
    public class WinCopyService : IFileCopyService
    {
        public async Task CopyFileAsync(string sourceFilePath, string destinationFilePath, bool overwrite)
        {
            if (string.IsNullOrEmpty(sourceFilePath) || string.IsNullOrEmpty(destinationFilePath))
                throw new ArgumentException("File paths must be provided.");

            // Platform-specific checks or logic can be added here if needed
            await Task.Run(() => File.Copy(sourceFilePath, destinationFilePath, overwrite));
        }

        public async Task MoveFileAsync(string sourceFilePath, string destinationFilePath)
        {
            if (string.IsNullOrEmpty(sourceFilePath) || string.IsNullOrEmpty(destinationFilePath))
                throw new ArgumentException("File paths must be provided.");

            await Task.Run(() => File.Move(sourceFilePath, destinationFilePath));
        }

        public async Task DeleteFileAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("File path must be provided.");

            await Task.Run(() => File.Delete(filePath));
        }

        public async Task<bool> FileExistsAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("File path must be provided.");

            return await Task.Run(() => File.Exists(filePath));
        }
    }
}
