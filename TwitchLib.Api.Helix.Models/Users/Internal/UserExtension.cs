using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Users.Internal
{
    public record UserExtension
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("version")]
        public string Version { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("can_activate")]
        public bool CanActivate { get; set; }
        [JsonPropertyName("type")]
        public string[] Type { get; set; }
    }
}
