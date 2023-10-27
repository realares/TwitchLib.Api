using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Channels.GetChannelInformation
{
    public class GetChannelInformationResponse
    {
        [JsonPropertyName("data")]
        public ChannelInformation[] Data { get; set; }
    }
}
