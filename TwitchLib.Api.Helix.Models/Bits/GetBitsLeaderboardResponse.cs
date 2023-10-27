using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Bits
{
    public class GetBitsLeaderboardResponse
    {
        [JsonPropertyName("data")]
        public Listing[] Listings { get; set; }
        [JsonPropertyName("date_range")]
        public DateRange DateRange { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
