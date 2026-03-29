using InstaFollow_Checker.Application.Interfaces;
using System.Text.Json;

namespace InstaFollow_Checker.Infraesttructure.Parsers
{
    internal class FollowingParserService : IGetFollowing
    {
        public IEnumerable<string> GetFollowing(string jsonContent)
        {
            using var document = JsonDocument.Parse(jsonContent);

            return document.RootElement
                .GetProperty("string_list_data")
                .EnumerateArray()
                .Select(x => x.GetProperty("href").GetString())
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(ExtractUsername)!;
        }

        private static string ExtractUsername(string url)
            => url.Split('/').Last();
    }
}
