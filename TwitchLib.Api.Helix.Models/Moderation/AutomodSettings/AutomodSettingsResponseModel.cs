using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Moderation.AutomodSettings
{
    public class AutomodSettingsResponseModel
    {
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId;
        [JsonPropertyName("moderator_id")]
        public string ModeratorId;
        [JsonPropertyName("overall_level")]
        public int? OverallLevel;
        [JsonPropertyName("disability")]
        public int? Disability;
        [JsonPropertyName("aggression")]
        public int? Aggression;
        [JsonPropertyName("sexuality_sex_or_gender")]
        public int? SexualitySexOrGender;
        [JsonPropertyName("misogyny")]
        public int? Misogyny;
        [JsonPropertyName("bullying")]
        public int? Bullying;
        [JsonPropertyName("swearing")]
        public int? Swearing;
        [JsonPropertyName("race_ethnicity_or_religion")]
        public int? RaceEthnicityOrReligion;
        [JsonPropertyName("sex_based_terms")]
        public int? SexBasedTerms;
    }
}
