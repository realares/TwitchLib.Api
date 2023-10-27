using System;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Soundtrack
{
    public class Album
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }
    }
}
