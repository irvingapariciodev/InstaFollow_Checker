using InstaFollow_Checker.Domain.Models;

namespace InstaFollow_Checker.Application.Interfaces
{
    public interface IFollowAnalysisService
    {
        IEnumerable<string> GetUsersNotFollowingBack(IEnumerable<string> followers, IEnumerable<string> following);

        int GetFollowersCount(IEnumerable<string> followers);

        int GetFollowingCount(IEnumerable<string> following);
    }
}
