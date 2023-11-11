using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Chat.Badges.GetChannelChatBadges
{
    public record GetChannelChatBadgesResponse
    {
        [JsonPropertyName("data")]
        public BadgeEmoteSet[] EmoteSet { get; set; }
    }
}
