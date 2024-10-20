using System.Threading.Tasks;

namespace WLib.Util.Services
{
    public interface IFileCopyService
    {
        /// <summary>
        /// Copies a file from source to destination asynchronously.
        /// </summary>
        /// <param name="sourceFilePath">The full path of the source file.</param>
        /// <param name="destinationFilePath">The full path of the destination file.</param>
        /// <param name="overwrite">Whether to overwrite the destination file if it exists.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CopyFileAsync(string sourceFilePath, string destinationFilePath, bool overwrite);

        /// <summary>
        /// Moves a file from source to destination asynchronously.
        /// </summary>
        /// <param name="sourceFilePath">The full path of the source file.</param>
        /// <param name="destinationFilePath">The full path of the destination file.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task MoveFileAsync(string sourceFilePath, string destinationFilePath);

        /// <summary>
        /// Deletes a file asynchronously.
        /// </summary>
        /// <param name="filePath">The full path of the file to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteFileAsync(string filePath);

        /// <summary>
        /// Checks if a file exists at the specified path asynchronously.
        /// </summary>
        /// <param name="filePath">The full path of the file to check.</param>
        /// <returns>A task representing the asynchronous operation, with a result indicating whether the file exists.</returns>
        Task<bool> FileExistsAsync(string filePath);
    }
}
