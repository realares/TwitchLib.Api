using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Predictions
{
    public record Outcome
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("users")]
        public int ChannelPoints { get; set; }
        [JsonPropertyName("channel_points")]
        public int ChannelPointsVotes { get; set; }
        [JsonPropertyName("top_predictors")]
        public TopPredictor[] TopPredictors { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
    }
}
