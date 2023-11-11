using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Users.Internal
{
    public record UserExtensionState
    {
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("version")]
        public string Version { get; set; }

        public UserExtensionState(bool active, string id, string version)
        {
            Active = active;
            Id = id;
            Version = version;
        }
    }
}
