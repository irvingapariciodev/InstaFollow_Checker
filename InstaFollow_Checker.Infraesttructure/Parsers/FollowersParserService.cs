using InstaFollow_Checker.Application.Interfaces;
using InstaFollow_Checker.Domain.Models;
using System.Text.Json;

namespace InstaFollow_Checker.Infraesttructure.Parsers
{
    public class FollowersParserService : IGetFollowers
    {
        public IEnumerable<InstagramUser> GetFollowers(string jsonContent)
        {
            var followers = new List<InstagramUser>();

            using var document = JsonDocument.Parse(jsonContent);

            foreach (var element in document.RootElement.EnumerateArray())
            {
                if (element.TryGetProperty("string_list_data", out var list))
                {
                    foreach (var item in list.EnumerateArray())
                    {
                        if (item.TryGetProperty("value", out var usernameElement))
                        {
                            var username = usernameElement.GetString();

                            if (!string.IsNullOrWhiteSpace(username))
                                followers.Add(new InstagramUser(username,string.Empty,long.MinValue));
                        }
                    }
                }
            }
            return followers;
        }
    }
}
