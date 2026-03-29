using InstaFollow_Checker.Application.Interfaces;

namespace InstaFollow_Checker.Infraesttructure.Services
{
    public class FileReaderService : IFileReader
    {
        public async Task<string> ReadFileAsync(Stream fileStream)
        {
            using var reader = new StreamReader(fileStream);
            return await reader.ReadToEndAsync();
        }
    }
}
