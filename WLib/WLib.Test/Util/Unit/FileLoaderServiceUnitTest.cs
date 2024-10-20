using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using System.Threading.Tasks;
using WLib.Util.Services;

namespace WLib.Test.Util.Unit
{
    [TestClass]
    public class FileLoaderServiceUnitTest
    {
        private Mock<ILogger<FileLoaderService>> _loggerMock;
        private FileLoaderService _fileLoaderService;

        [TestInitialize]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<FileLoaderService>>();
            _fileLoaderService = new FileLoaderService(_loggerMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public async Task LoadFile_FileDoesNotExist_ThrowsFileNotFoundException()
        {
            // Arrange
            var filePath = "nonexistentfile.txt";

            // Act
            await _fileLoaderService.LoadFile(filePath);

            // Assert
            // Expected exception is handled by ExpectedException attribute
        }

        [TestMethod]
        public async Task LoadFile_FileExists_ReturnsFileContent()
        {
            // Arrange
            var filePath = "testfile.txt";
            var fileContent = "Test file content";
            File.WriteAllText(filePath, fileContent);

            // Act
            var result = await _fileLoaderService.LoadFile(filePath);

            // Assert
            Assert.AreEqual(fileContent, result);

            // Cleanup
            File.Delete(filePath);
        }

        [TestMethod]
        public async Task SaveStringToFile_ValidFile_SavesContentSuccessfully()
        {
            // Arrange
            var filePath = "outputfile.txt";
            var content = "Sample content";

            // Act
            await _fileLoaderService.SaveStringToFile(filePath, content);

            // Assert
            Assert.IsTrue(File.Exists(filePath));
            Assert.AreEqual(content, File.ReadAllText(filePath));

            // Cleanup
            File.Delete(filePath);
        }

        [TestMethod]
        public async Task LoadFileAndDeSerialize_ValidJson_ReturnsObject()
        {
            // Arrange
            var filePath = "valid.json";
            var jsonContent = "{\"Name\":\"Test\",\"Value\":123}";
            File.WriteAllText(filePath, jsonContent);

            // Act
            var result = await _fileLoaderService.LoadFileAndDeSerialize<TestObject>(filePath);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test", result.Name);
            Assert.AreEqual(123, result.Value);

            // Cleanup
            File.Delete(filePath);
        }

        private class TestObject
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
    }
}
