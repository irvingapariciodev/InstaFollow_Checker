using InstaFollow_Checker.Domain.Models;

namespace InstaFollow_Checker.Application.Interfaces
{
    public interface IGetFollowers
    {
        IEnumerable<string> GetFollowers(string jsonContent);
    }
}
