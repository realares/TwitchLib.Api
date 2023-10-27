using System.Text.Json.Serialization;

namespace TwitchLib.Api.ThirdParty.ModLookup
{
    public class Stats
    {
        [JsonPropertyName("relations")]
        public int Relations { get; set; }
        [JsonPropertyName("channels_total")]
        public int ChannelsTotal { get; set; }
        [JsonPropertyName("users")]
        public int Users { get; set; }
        [JsonPropertyName("channels_no_mods")]
        public int ChannelsNoMods { get; set; }
        [JsonPropertyName("channels_only_broadcaster")]
        public int ChannelsOnlyBroadcaster { get; set; }
    }
}
