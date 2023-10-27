using System.Text.Json.Serialization;

namespace TwitchLib.Api.Core.Models.Undocumented.CSStreams
{
    public class CSStream
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }
        [JsonPropertyName("game")]
        public string Game { get; set; }
        [JsonPropertyName("viewers")]
        public int Viewers { get; set; }
        [JsonPropertyName("map")]
        public string Map { get; set; }
        [JsonPropertyName("map_name")]
        public string MapName { get; set; }
        [JsonPropertyName("map_img")]
        public string MapImg { get; set; }
        [JsonPropertyName("skill")]
        public int Skill { get; set; }
        [JsonPropertyName("preview")]
        public Preview Preview { get; set; }
        [JsonPropertyName("is_playlist")]
        public bool IsPlaylist { get; set; }
        [JsonPropertyName("user")]
        public User User { get; set; }
    }
}
