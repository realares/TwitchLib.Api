using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Bits
{
    public class Listing
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; }
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }
        [JsonPropertyName("rank")]
        public int Rank { get; set; }
        [JsonPropertyName("score")]
        public int Score { get; set; }
    }
}
