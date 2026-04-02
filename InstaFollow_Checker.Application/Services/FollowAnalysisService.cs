using InstaFollow_Checker.Application.Interfaces;
using InstaFollow_Checker.Domain.Models;
using System.Linq;

namespace InstaFollow_Checker.Application.Services
{
    public class FollowAnalysisService : IFollowAnalysisService
    {
        public int GetFollowersCount(IEnumerable<InstagramUser> followers)
        {
            int totalFollowers = followers.Count();
            try
            {
                if (totalFollowers <= 0)
                {
                    Console.WriteLine($"No followers were found");
                    return totalFollowers;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot identify followers - {ex.Message}");
                return 0;
            }
            return totalFollowers;
        }

        public int GetFollowingCount(IEnumerable<InstagramUser> following)
        {
            int totalFollowing = following.Count();
            try
            {
                if (totalFollowing <= 0)
                {
                    Console.WriteLine($"No followers were found");
                    return totalFollowing;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot identify followers - {ex.Message}");
                return 0;
            }
            return totalFollowing;
        }

        public IEnumerable<string> GetUsersNotFollowingBack(IEnumerable<InstagramUser> followers, IEnumerable<InstagramUser> following)
        {
            try
            {
                if (followers == null || following == null)
                {
                    Console.WriteLine($"Followers or following list is null");
                    return [];
                }

                var GetInstagramFollowersUsername = ClearDuplicateFollowers(followers);
                var GetInstagramFollowingUsername = ClearDuplicateFollowing(following);

                IEnumerable<string> notFollowingBack = [];

                notFollowingBack = GetInstagramFollowingUsername.Except(GetInstagramFollowersUsername);

                return notFollowingBack;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot identify who follows back - {ex.Message}");
                return [];
            }
        }

        public IEnumerable<string> ClearDuplicateFollowers(IEnumerable<InstagramUser> followers)
        {
            _ = Enumerable.Empty<string>();
            IEnumerable<string>? GetInstagramFollowersUsername = GetUsernameFollowers(followers);
            GetInstagramFollowersUsername = [.. GetInstagramFollowersUsername.Distinct()];
            return GetInstagramFollowersUsername;
        }

        public IEnumerable<string> ClearDuplicateFollowing(IEnumerable<InstagramUser> following)
        {
            _ = Enumerable.Empty<string>();
            IEnumerable<string>? GetInstagramFollowingUsername = GetUsernameFollowers(following);
            GetInstagramFollowingUsername = [.. GetInstagramFollowingUsername.Distinct()];
            return GetInstagramFollowingUsername;
        }

        public IEnumerable<string> GetUsernameFollowers(IEnumerable<InstagramUser> followers)
        {
            var followersUsername = Enumerable.Empty<string>();
            foreach (var getUsername in followers)
            {
                followersUsername = [.. followers.Select(user => user.Username)];
            }
            return followersUsername;
        }

        public IEnumerable<string> GetUsernameFollowing(IEnumerable<InstagramUser> following)
        {
            var followingUsername = Enumerable.Empty<string>();
            foreach (var getUsername in following)
            {
                followingUsername = [.. following.Select(user => user.Username)];
            }
            return followingUsername;
        }
    }
}
