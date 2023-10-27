using System.Text.Json.Serialization;

namespace TwitchLib.Api.Core.Models.Undocumented.Chatters
{
    public class Chatters
    {
        [JsonPropertyName("moderators")]
        public string[] Moderators { get; set; }
        [JsonPropertyName("staff")]
        public string[] Staff { get; set; }
        [JsonPropertyName("admins")]
        public string[] Admins { get; set; }
        [JsonPropertyName("global_mods")]
        public string[] GlobalMods { get; set; }
        [JsonPropertyName("vips")]
        public string[] VIP { get; set; }
        [JsonPropertyName("viewers")]
        public string[] Viewers { get; set; }
    }
}
