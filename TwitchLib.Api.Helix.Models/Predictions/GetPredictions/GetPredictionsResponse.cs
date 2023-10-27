﻿using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.Predictions.GetPredictions
{
    public class GetPredictionsResponse
    {
        [JsonPropertyName("data")]
        public Prediction[] Data { get; set; }
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
    }
}
