using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Predictions.CreatePrediction
{
    public record CreatePredictionResponse
    {
        [JsonPropertyName("data")]
        public Prediction[] Data { get; set; }
    }
}
