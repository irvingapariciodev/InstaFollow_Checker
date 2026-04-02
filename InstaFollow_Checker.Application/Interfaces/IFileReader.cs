namespace InstaFollow_Checker.Application.Interfaces
{
    public interface IFileReader
    {
        public Task<string> ReadFileAsync(Stream fileStream);
    }
}
