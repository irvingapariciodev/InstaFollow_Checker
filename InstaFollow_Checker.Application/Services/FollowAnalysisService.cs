using InstaFollow_Checker.Application.Interfaces;

namespace InstaFollow_Checker.Application.Services
{
    public class FollowAnalysisService : IFollowAnalysisService
    {
        public int GetFollowersCount(IEnumerable<string> followers)
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

        public int GetFollowingCount(IEnumerable<string> following)
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

        public IEnumerable<string> GetUsersNotFollowingBack(IEnumerable<string> followers, IEnumerable<string> following)
        {
            try
            {
                if (followers == null || following == null)
                {
                    Console.WriteLine($"Followers or following list is null");
                    return Enumerable.Empty<string>();
                }
                var notFollowingBack = following.Except(followers);
                return notFollowingBack;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot identify who follows back - {ex.Message}");
                return Enumerable.Empty<string>();
            }
        }
    }
}
