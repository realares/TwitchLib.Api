using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Chat
{
    public record ChattersResponseModel
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; } = null!;

        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; } = null!;

        [JsonPropertyName("user_name")]
        public string UserName { get; set; } = null!;
    }
}
