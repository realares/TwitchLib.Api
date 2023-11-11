
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.ContentClassificationLabels
{
    /// <summary>
    /// <para>The list of Content Classification Labels available.</para>
    /// </summary>
    public record ContentClassificationLabel
    {
        /// <summary>
        /// <para>Unique identifier for the Content Classification Labels.</para>
        /// </summary>
        [JsonPropertyName("id")]
        public string ID { get; set; } = null!;

        /// <summary>
        /// <para>Localized description of the Content Classification Labels.</para>
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        /// <summary>
        /// <para>Localized name of the Content Classification Labels.</para>
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
    }
}
