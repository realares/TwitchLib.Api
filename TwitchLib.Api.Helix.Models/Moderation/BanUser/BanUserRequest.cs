using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Moderation.BanUser
{
    public class BanUserRequest
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; } = null!;

        [JsonPropertyName("reason")]
        public string Reason { get; set; } = null!;

        [JsonPropertyName("duration")]
        public int? Duration { get; set; }
    }
}