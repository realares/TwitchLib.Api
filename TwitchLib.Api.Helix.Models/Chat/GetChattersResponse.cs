using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Chat
{
    public record GetChattersResponse
    {
        [JsonPropertyName("data")]
        public ChattersResponseModel[] Data { get; set; } = null!;

        [JsonPropertyName("pagination")]
        public Common.Pagination Pagination { get; set; } = null!;

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
