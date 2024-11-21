using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.Chat.ChatSettings
{
    public record GetChatSettingsResponse
    {
        [JsonPropertyName("data")]
        public ChatSettingsResponseModel[] Data { get; set; } = null!;

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; } = null!;

        [JsonPropertyName("total")]
        public int Total { get; set; } 
    }
}
