using InstaFollow_Checker.Application.Interfaces;
using System.Text.Json;

namespace InstaFollow_Checker.Infraesttructure.Parsers
{
    public class FollowersParserService : IGetFollowers
    {
        public IEnumerable<string> GetFollowers(string jsonContent)
        {
            var followers = new List<string>();

            using var document = JsonDocument.Parse(jsonContent);

            foreach (var element in document.RootElement.EnumerateArray())
            {
                if (element.TryGetProperty("string_list_data", out var list))
                {
                    foreach (var item in list.EnumerateArray())
                    {
                        if (item.TryGetProperty("value", out var username))
                        {
                            followers.Add(username.GetString() ?? string.Empty);
                        }
                    }
                }
            }
            return followers;
        }
    }
}
