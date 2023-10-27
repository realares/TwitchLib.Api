using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Moderation.BanUser
{
    public class BanUserResponse
    {
        [JsonPropertyName("data")]
        public BannedUser[] Data { get; set; }
    }
}
