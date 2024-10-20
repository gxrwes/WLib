using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WLib.Util.Services
{
    public class WinCopyService : IFileCopyService
    {
        private readonly ILogger<WinCopyService> _logger;

        public WinCopyService(ILogger<WinCopyService> logger)
        {
            _logger = logger;
        }

        public async Task CopyFileAsync(string sourceFilePath, string destinationFilePath, bool overwrite)
        {
            _logger.LogInformation("Copying file from {SourceFilePath} to {DestinationFilePath}", sourceFilePath, destinationFilePath);
            await Task.Run(() => File.Copy(sourceFilePath, destinationFilePath, overwrite));
            _logger.LogInformation("File copied successfully.");
        }

        public async Task MoveFileAsync(string sourceFilePath, string destinationFilePath)
        {
            _logger.LogInformation("Moving file from {SourceFilePath} to {DestinationFilePath}", sourceFilePath, destinationFilePath);
            await Task.Run(() => File.Move(sourceFilePath, destinationFilePath));
            _logger.LogInformation("File moved successfully.");
        }

        public async Task DeleteFileAsync(string filePath)
        {
            _logger.LogInformation("Deleting file: {FilePath}", filePath);
            await Task.Run(() => File.Delete(filePath));
            _logger.LogInformation("File deleted successfully.");
        }

        public async Task<bool> FileExistsAsync(string filePath)
        {
            _logger.LogInformation("Checking if file exists: {FilePath}", filePath);
            return await Task.Run(() => File.Exists(filePath));
        }
    }
}
