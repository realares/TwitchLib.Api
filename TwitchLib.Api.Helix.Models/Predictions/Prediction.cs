using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Api.Core.Enums;

namespace TwitchLib.Api.Helix.Models.Predictions
{
    public record Prediction
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
        [JsonPropertyName("winning_outcome_id")]
        public string WinningOutcomeId { get; set; }
        [JsonPropertyName("outcomes")]
        public Outcome[] Outcomes { get; set; }
        [JsonPropertyName("prediction_window")]
        public string PredictionWindow { get; set; }
        [JsonPropertyName("status")]
        public PredictionStatus Status { get; set; }
        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }
        [JsonPropertyName("ended_at")]
        public string EndedAt { get; set; }
        [JsonPropertyName("locked_at")]
        public string LockedAt { get; set; }        
    }
}
