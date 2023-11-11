using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Predictions.CreatePrediction
{
    public record Outcome
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
