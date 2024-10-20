using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Threading.Tasks;
using WLib.Util.Services;

namespace WLib.Test.Util.Unit
{
    [TestClass]
    public class FileCopyServiceUnitTest
    {
        private WinCopyService _winCopyService;
        private LinuxCopyService _linuxCopyService;

        [TestInitialize]
        public void Setup()
        {
            _winCopyService = new WinCopyService();
            _linuxCopyService = new LinuxCopyService();
        }

        // WinCopyService Tests

        [TestMethod]
        public async Task WinCopyService_CopyFileAsync_CopiesFileSuccessfully()
        {
            // Arrange
            var sourceFilePath = "source.txt";
            var destinationFilePath = "destination.txt";
            File.WriteAllText(sourceFilePath, "Test content");

            // Act
            await _winCopyService.CopyFileAsync(sourceFilePath, destinationFilePath, true);

            // Assert
            Assert.IsTrue(File.Exists(destinationFilePath));
            Assert.AreEqual(File.ReadAllText(sourceFilePath), File.ReadAllText(destinationFilePath));

            // Cleanup
            File.Delete(sourceFilePath);
            File.Delete(destinationFilePath);
        }

        [TestMethod]
        public async Task WinCopyService_MoveFileAsync_MovesFileSuccessfully()
        {
            // Arrange
            var sourceFilePath = "source.txt";
            var destinationFilePath = "destination.txt";
            File.WriteAllText(sourceFilePath, "Test content");

            // Act
            await _winCopyService.MoveFileAsync(sourceFilePath, destinationFilePath);

            // Assert
            Assert.IsTrue(File.Exists(destinationFilePath));
            Assert.IsFalse(File.Exists(sourceFilePath));

            // Cleanup
            File.Delete(destinationFilePath);
        }

        [TestMethod]
        public async Task WinCopyService_DeleteFileAsync_DeletesFileSuccessfully()
        {
            // Arrange
            var filePath = "fileToDelete.txt";
            File.WriteAllText(filePath, "Test content");

            // Act
            await _winCopyService.DeleteFileAsync(filePath);

            // Assert
            Assert.IsFalse(File.Exists(filePath));
        }

        [TestMethod]
        public async Task WinCopyService_FileExistsAsync_ReturnsTrueIfFileExists()
        {
            // Arrange
            var filePath = "existingFile.txt";
            File.WriteAllText(filePath, "Test content");

            // Act
            var exists = await _winCopyService.FileExistsAsync(filePath);

            // Assert
            Assert.IsTrue(exists);

            // Cleanup
            File.Delete(filePath);
        }

        // LinuxCopyService Tests

        [TestMethod]
        public async Task LinuxCopyService_CopyFileAsync_CopiesFileSuccessfully()
        {
            // Arrange
            var sourceFilePath = "source.txt";
            var destinationFilePath = "destination.txt";
            File.WriteAllText(sourceFilePath, "Test content");

            // Act
            await _linuxCopyService.CopyFileAsync(sourceFilePath, destinationFilePath, true);

            // Assert
            Assert.IsTrue(File.Exists(destinationFilePath));
            Assert.AreEqual(File.ReadAllText(sourceFilePath), File.ReadAllText(destinationFilePath));

            // Cleanup
            File.Delete(sourceFilePath);
            File.Delete(destinationFilePath);
        }

        [TestMethod]
        public async Task LinuxCopyService_MoveFileAsync_MovesFileSuccessfully()
        {
            // Arrange
            var sourceFilePath = "source.txt";
            var destinationFilePath = "destination.txt";
            File.WriteAllText(sourceFilePath, "Test content");

            // Act
            await _linuxCopyService.MoveFileAsync(sourceFilePath, destinationFilePath);

            // Assert
            Assert.IsTrue(File.Exists(destinationFilePath));
            Assert.IsFalse(File.Exists(sourceFilePath));

            // Cleanup
            File.Delete(destinationFilePath);
        }

        [TestMethod]
        public async Task LinuxCopyService_DeleteFileAsync_DeletesFileSuccessfully()
        {
            // Arrange
            var filePath = "fileToDelete.txt";
            File.WriteAllText(filePath, "Test content");

            // Act
            await _linuxCopyService.DeleteFileAsync(filePath);

            // Assert
            Assert.IsFalse(File.Exists(filePath));
        }

        [TestMethod]
        public async Task LinuxCopyService_FileExistsAsync_ReturnsTrueIfFileExists()
        {
            // Arrange
            var filePath = "existingFile.txt";
            File.WriteAllText(filePath, "Test content");

            // Act
            var exists = await _linuxCopyService.FileExistsAsync(filePath);

            // Assert
            Assert.IsTrue(exists);

            // Cleanup
            File.Delete(filePath);
        }
    }
}
