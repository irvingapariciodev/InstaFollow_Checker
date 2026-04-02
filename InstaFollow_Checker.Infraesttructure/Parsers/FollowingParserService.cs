using InstaFollow_Checker.Application.Interfaces;
using InstaFollow_Checker.Domain.Models;
using System.Text.Json;

namespace InstaFollow_Checker.Infraesttructure.Parsers
{
    internal class FollowingParserService : IGetFollowing
    {
        public IEnumerable<InstagramUser> GetFollowing(string jsonContent)
        {
            using var document = JsonDocument.Parse(jsonContent);

            var followers = new List<InstagramUser>();

            if (document.RootElement.ValueKind == JsonValueKind.Array)
            {
                ParseArray(document.RootElement, followers);
            }
            else if (document.RootElement.ValueKind == JsonValueKind.Object)
            {
                if (document.RootElement.TryGetProperty("relationships_following", out var followersArray))
                {
                    ParseArray(followersArray, followers);
                }
            }

            return followers;
        }

        private static void ParseArray(JsonElement array, List<InstagramUser> followers)
        {
            foreach (var element in array.EnumerateArray())
            {
                if (!element.TryGetProperty("string_list_data", out var list))
                    continue;

                foreach (var item in list.EnumerateArray())
                {
                    if (item.TryGetProperty("href", out var urlProfile))
                    {
                        var username = urlProfile.GetString();

                        if (!string.IsNullOrWhiteSpace(username))
                        {
                            username = username.Replace("https://www.instagram.com/_u/", "").TrimEnd('/');
                            followers.Add(new InstagramUser(username, item.GetProperty("href").ToString(), long.MinValue));
                        }
                    }
                }
            }
        }
    }
}
