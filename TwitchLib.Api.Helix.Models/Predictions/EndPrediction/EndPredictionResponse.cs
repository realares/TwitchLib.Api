using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Predictions.EndPrediction
{
    public record EndPredictionResponse
    {
        [JsonPropertyName("data")]
        public Prediction[] Data { get; set; }
    }
}
