﻿using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Bits.ExtensionBitsProducts
{
    public class GetExtensionBitsProductsResponse
    {
        [JsonPropertyName("data")]
        public ExtensionBitsProduct[] Data { get; set; }
    }
}
