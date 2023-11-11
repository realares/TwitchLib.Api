using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Chat.Badges.GetGlobalChatBadges
{
    public record GetGlobalChatBadgesResponse
    {
        [JsonPropertyName("data")]
        public BadgeEmoteSet[] EmoteSet { get; set; }
    }
}
