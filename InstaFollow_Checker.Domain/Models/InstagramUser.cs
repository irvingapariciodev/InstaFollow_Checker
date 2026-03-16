namespace InstaFollow_Checker.Domain.Models
{
    public class InstagramUser(string username, string profileURL, long timestamp)
    {
        public string Username { get; set; } = username;
        public string ProfileURL { get; set; } = profileURL;
        public long Timestamp { get; set; } = timestamp;

        public override string ToString()
        {
            return $"Instagram user: {Username} (href: {ProfileURL}, timestamp: {Timestamp})";
        }
    }
}