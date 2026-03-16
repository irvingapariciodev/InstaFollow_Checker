using InstaFollow_Checker.Application.DTO;
using InstaFollow_Checker.Application.Interfaces;

namespace InstaFollow_Checker.Application.UseCases
{
    public class AnalyzeInstagramFollowsUseCase
    {
        private readonly IFileReader _fileReader;
        private readonly IGetFollowing _getFollowing;
        private readonly IGetFollowers _getFollowers;
        private readonly IFollowAnalysisService _followAnalysisService;

        public AnalyzeInstagramFollowsUseCase(IFileReader fileReader, IGetFollowing getFollowing, IGetFollowers getFollowers, IFollowAnalysisService followAnalysisService)
        {
            _fileReader = fileReader;
            _getFollowing = getFollowing;
            _getFollowers = getFollowers;
            _followAnalysisService = followAnalysisService;
        }

        public async Task<FollowAnalysisResultDto> ExecuteAsync(Stream followersFile, Stream followingFile)
        {
            var followersJson = await _fileReader.ReadFileAsync(followersFile);
            var followingJson = await _fileReader.ReadFileAsync(followingFile);

            var followers = _getFollowers.GetFollowers(followersJson);
            var following = _getFollowing.GetFollowing(followingJson);

            var usersNotFollowingBack = _followAnalysisService.GetUsersNotFollowingBack(followers, following);

            return new FollowAnalysisResultDto
            {
                FollowersCount = _followAnalysisService.GetFollowersCount(followers),
                FollowingCount = _followAnalysisService.GetFollowingCount(following),
                NotFollowingBackCount = usersNotFollowingBack.Count(),
                UsersNotFollowingBack = usersNotFollowingBack
            };
        }
    }
}
