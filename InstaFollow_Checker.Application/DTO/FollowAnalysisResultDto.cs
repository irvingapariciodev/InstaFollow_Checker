namespace InstaFollow_Checker.Application.DTO
{
    public class FollowAnalysisResultDto
    {
        public int FollowersCount { get; set; }

        public int FollowingCount { get; set; }

        public int NotFollowingBackCount { get; set; }

        public IEnumerable<string> UsersNotFollowingBack { get; set; } = new List<string>();
    }
}
