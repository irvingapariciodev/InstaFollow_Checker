using InstaFollow_Checker.Domain.Models;

namespace InstaFollow_Checker.Application.Interfaces
{
    public interface IFollowAnalysisService
    {
        int GetFollowersCount(IEnumerable<InstagramUser> followers);

        int GetFollowingCount(IEnumerable<InstagramUser> following);

        IEnumerable<string> GetUsersNotFollowingBack(IEnumerable<InstagramUser> followers, IEnumerable<InstagramUser> following);

        IEnumerable<string> ClearDuplicateFollowers(IEnumerable<InstagramUser> followers);

        IEnumerable<string> ClearDuplicateFollowing(IEnumerable<InstagramUser> following);

        IEnumerable<string> GetUsernameFollowers(IEnumerable<InstagramUser> followers);

        IEnumerable<string> GetUsernameFollowing(IEnumerable<InstagramUser> following);
    }
}
