using InstaFollow_Checker.Application.Interfaces;
using System.Text.Json;

namespace InstaFollow_Checker.Infraesttructure.Parsers
{
    internal class FollowingParserService : IGetFollowing
    {
        public IEnumerable<string> GetFollowing(string jsonContent)
        {
            using var document = JsonDocument.Parse(jsonContent);

            var followers = new List<string>();

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

        private static void ParseArray(JsonElement array, List<string> result)
        {
            foreach (var element in array.EnumerateArray())
            {
                if (!element.TryGetProperty("string_list_data", out var list))
                    continue;

                foreach (var item in list.EnumerateArray())
                {
                    if (item.TryGetProperty("href", out var username))
                    {
                        result.Add(username.GetString().Replace("https://www.instagram.com/_u/", "") ?? string.Empty);
                    }
                }
            }
        }
    }
}
