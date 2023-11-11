using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Polls
{
    public record Poll
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; }
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("choices")]
        public Choice[] Choices { get; set; }
        [JsonPropertyName("bits_voting_enabled")]
        public bool BitsVotingEnabled { get; set; }
        [JsonPropertyName("bits_per_vote")]
        public int BitsPerVote { get; set; }
        [JsonPropertyName("channel_points_voting_enabled")]
        public bool ChannelPointsVotingEnabled { get; set; }
        [JsonPropertyName("channel_points_per_vote")]
        public int ChannelPointsPerVote { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("duration")]
        public int DurationSeconds { get; set; }
        [JsonPropertyName("started_at")]
        public DateTime StartedAt { get; set; }
    }
}
