using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Teams
{
    public record GetChannelTeamsResponse
    {
        [JsonPropertyName("data")]
        public ChannelTeam[] ChannelTeams { get; set; }
    }
}