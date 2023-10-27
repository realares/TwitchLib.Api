using System.Text.Json.Serialization;

namespace TwitchLib.Api.ThirdParty.ModLookup
{
    public class ModLookupListing
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("followers")]
        public int Followers { get; set; }
        [JsonPropertyName("views")]
        public int Views { get; set; }
        [JsonPropertyName("partnered")]
        public bool Partnered { get; set; }
    }
}
