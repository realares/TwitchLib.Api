using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Clips.CreateClip
{
    /// <summary>
    /// A Twitch clip created from CreateClip
    /// </summary>
    public class CreatedClip
    {
        /// <summary>
        /// <para>A URL that you can use to edit the clip’s title, identify the part of the clip to publish, and publish the clip.</para>
        /// <para> The URL is valid for up to 24 hours or until the clip is published, whichever comes first.</para>
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// An ID that uniquely identifies the clip.
        /// </summary>
        [JsonPropertyName("edit_url")]
        public string EditUrl { get; set; } = null!;
    }
}
