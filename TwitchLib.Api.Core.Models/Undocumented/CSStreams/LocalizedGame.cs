using System.Text.Json.Serialization;

namespace TwitchLib.Api.Core.Models.Undocumented.CSStreams
{
    public class LocalizedGame
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("popularity")]
        public int Popularity { get; set; }
        [JsonPropertyName("_id")]
        public string Id { get; set; }
        [JsonPropertyName("giantbomb_id")]
        public string GiantbombId { get; set; }
        [JsonPropertyName("box")]
        public Box Box { get; set; }
        [JsonPropertyName("logo")]
        public Logo Logo { get; set; }
        [JsonPropertyName("localized_name")]
        public string LocalizedName { get; set; }
        [JsonPropertyName("locale")]
        public string Locale { get; set; }
    }
}
