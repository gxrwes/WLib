using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WLib.Util.Services
{
    public class FileLoaderService : IFileLoaderService
    {
        private readonly ILogger<FileLoaderService> _logger;

        public FileLoaderService(ILogger<FileLoaderService> logger)
        {
            _logger = logger;
        }

        public async Task<string> LoadFile(string filePath)
        {
            _logger.LogInformation("Attempting to load file: {FilePath}", filePath);

            if (!File.Exists(filePath))
            {
                _logger.LogError("File not found: {FilePath}", filePath);
                throw new FileNotFoundException($"File not found: {filePath}");
            }

            using var reader = new StreamReader(filePath);
            var content = await reader.ReadToEndAsync();

            _logger.LogInformation("Successfully loaded file: {FilePath}", filePath);
            return content;
        }

        public async Task<T> LoadFileAndDeSerialize<T>(string filePath)
        {
            _logger.LogInformation("Attempting to deserialize file: {FilePath}", filePath);
            var content = await LoadFile(filePath);

            try
            {
                var obj = JsonConvert.DeserializeObject<T>(content);
                _logger.LogInformation("Successfully deserialized file: {FilePath}", filePath);
                return obj;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error deserializing file: {FilePath}. Error: {ErrorMessage}", filePath, ex.Message);
                throw;
            }
        }

        public async Task SaveObjectToFile<T>(string filePath, T obj)
        {
            _logger.LogInformation("Attempting to save object to file: {FilePath}", filePath);
            var json = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
            await SaveStringToFile(filePath, json);
        }

        public async Task SaveStringToFile(string filePath, string content)
        {
            _logger.LogInformation("Attempting to save string content to file: {FilePath}", filePath);

            try
            {
                using var writer = new StreamWriter(filePath, false); // 'false' to overwrite
                await writer.WriteAsync(content);
                _logger.LogInformation("Successfully saved content to file: {FilePath}", filePath);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error saving content to file: {FilePath}. Error: {ErrorMessage}", filePath, ex.Message);
                throw;
            }
        }
    }
}
