using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Clips.CreateClip
{
    public class CreatedClip
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("edit_url")]
        public string EditUrl { get; set; }
    }
}
