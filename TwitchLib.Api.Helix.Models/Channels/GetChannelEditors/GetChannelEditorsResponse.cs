using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Channels.GetChannelEditors
{
    public class GetChannelEditorsResponse
    {
        [JsonPropertyName("data")]
        public ChannelEditor[] Data { get; set; }
    }
}
