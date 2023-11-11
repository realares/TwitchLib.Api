using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Clips.CreateClip
{
    /// <summary>
    /// Response for CreateClip which creates a clip from the broadcaster's stream.
    /// </summary>
    public record CreatedClipResponse
    {
        /// <summary>
        /// Contains clip's ID and edit_URL that can be used to edit the clip's title, identify the part of the clip to publish, and publish the clip.
        /// </summary>
        [JsonPropertyName("data")]
        public CreatedClip[] CreatedClips { get; set; } = null!;
    }
}
