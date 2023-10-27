using System.Text.Json.Serialization;

namespace TwitchLib.Api.ThirdParty.ModLookup
{
    public class Top
    {
        [JsonPropertyName("modcount")]
        public ModLookupListing[] ModCount { get; set; }
        [JsonPropertyName("views")]
        public ModLookupListing[] Views { get; set; }
        [JsonPropertyName("followers")]
        public ModLookupListing[] Followers { get; set; }
    }
}
