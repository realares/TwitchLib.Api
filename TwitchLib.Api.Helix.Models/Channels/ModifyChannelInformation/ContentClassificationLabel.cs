using System.Text.Json.Serialization;
using TwitchLib.Api.Core.Enums;

namespace TwitchLib.Api.Helix.Models.Channels.ModifyChannelInformation
{
    /// <summary>
    /// <para>Labels that can be set for the channel's Content Classification Labels</para>
    /// </summary>
    public record ContentClassificationLabel
    {
        /// <summary>
        /// <para>ID of the Content Classification Labels that must be added/removed from the channel.</para>
        /// <para>Can be one of the following values:
        /// DrugsIntoxication, SexualThemes, ViolentGraphic, Gambling, ProfanityVulgarity</para>
        /// </summary>
        [JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        [JsonPropertyName("id")]
        public ContentClassificationLabelEnum Id { get; set; }

        /// <summary>
        /// <para>Boolean flag indicating whether the label should be enabled (true) or disabled (false) for the channel.</para>
        /// </summary>
        [JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; set; }
    }
}
