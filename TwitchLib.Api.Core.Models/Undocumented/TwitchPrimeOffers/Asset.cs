using System.Text.Json.Serialization;

namespace TwitchLib.Api.Core.Models.Undocumented.TwitchPrimeOffers
{
    public class Asset
    {
        [JsonPropertyName("assetType")]
        public string AssetType { get; set; }
        [JsonPropertyName("location")]
        public string Location { get; set; }
        [JsonPropertyName("location2x")]
        public string Location2x { get; set; }
        [JsonPropertyName("mediaType")]
        public string MediaType { get; set; }
    }
}
