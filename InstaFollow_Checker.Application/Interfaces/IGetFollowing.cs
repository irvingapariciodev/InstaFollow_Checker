using InstaFollow_Checker.Domain.Models;

namespace InstaFollow_Checker.Application.Interfaces
{
    public interface IGetFollowing
    {
        IEnumerable<string> GetFollowing(string jsonContent);
    }
}
