﻿using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Moderation.AutomodSettings
{
    public record GetAutomodSettingsResponse
    {
        [JsonPropertyName("data")]
        public AutomodSettingsResponseModel[] Data { get; set; }
    }
}
