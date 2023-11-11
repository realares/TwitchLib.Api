using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Polls
{
    public record Choice
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("votes")]
        public int Votes { get; set; }
        [JsonPropertyName("channel_points_votes")]
        public int ChannelPointsVotes { get; set; }
        [JsonPropertyName("bits_votes")]
        public int BitsVotes { get; set; }
    }
}
