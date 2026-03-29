using Microsoft.AspNetCore.Mvc;
using InstaFollow_Checker.Application.UseCases;

namespace InstaFollow_Checker.API.Controllers
{
    [ApiController]
    [Route("api/follow-analysis")]
    public class FollowAnalysisController : ControllerBase
    {
        private readonly AnalyzeInstagramFollowsUseCase _useCase;

        public FollowAnalysisController(AnalyzeInstagramFollowsUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        public async Task<IActionResult> Analyze(IFormFile followersFile, IFormFile followingFile)
        {
            if (followersFile == null || followingFile == null)
                return BadRequest("Both files are required.");

            using var followersStream = followersFile.OpenReadStream();
            using var followingStream = followingFile.OpenReadStream();

            var result = await _useCase.ExecuteAsync(followersStream, followingStream);

            return Ok(result);
        }
    }
}
