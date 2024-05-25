using System;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Clips.GetClips
{
    /// <summary>
    /// A clip that was created from a broadcaster's stream.
    /// </summary>
    public record Clip
    {
        /// <summary>
        /// An ID that uniquely identifies the clip.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// A URL to the clip.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; } = null!;

        /// <summary>
        /// A URL that you can use in an iframe to embed the clip.
        /// </summary>
        [JsonPropertyName("embed_url")]
        public string EmbedUrl { get; set; } = null!;

        /// <summary>
        /// An ID that identifies the broadcaster that the video was clipped from.
        /// </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; } = null!;

        /// <summary>
        /// The broadcaster’s display name.
        /// </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; } = null!;

        /// <summary>
        /// An ID that identifies the user that created the clip.
        /// </summary>
        [JsonPropertyName("creator_id")]
        public string CreatorId { get; set; } = null!;

        /// <summary>
        /// The display name of the user that created the clip.
        /// </summary>
        [JsonPropertyName("creator_name")]
        public string CreatorName { get; set; } = null!;

        /// <summary>
        /// <para>An ID that identifies the video that the clip came from.</para>
        /// <para>This field contains an empty string if the video is not available.</para>
        /// </summary>
        [JsonPropertyName("video_id")]
        public string VideoId { get; set; } = null!;

        /// <summary>
        /// The ID of the game that was being played when the clip was created.
        /// </summary>
        [JsonPropertyName("game_id")]
        public string GameId { get; set; } = null!;

        /// <summary>
        /// <para>The ISO 639-1 two-letter language code that the broadcaster broadcasts in. For example, en for English.</para>
        /// <para>The value is other if the broadcaster uses a language that Twitch doesn’t support.</para>
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; } = null!;

        /// <summary>
        /// The title of the clip.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;

        /// <summary>
        /// The number of times the clip has been viewed.
        /// </summary>
        [JsonPropertyName("view_count")]
        public int ViewCount { get; set; }

        /// <summary>
        /// The date and time of when the clip was created. The date and time is in RFC3339 format.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// A URL to a thumbnail image of the clip.
        /// </summary>
        [JsonPropertyName("thumbnail_url")]
        public string ThumbnailUrl { get; set; } = null!;

        /// <summary>
        /// The length of the clip, in seconds. Precision is 0.1.
        /// </summary>
        [JsonPropertyName("duration")]
        public float Duration { get; set; }

        /// <summary>
        /// <para>The zero-based offset, in seconds, to where the clip starts in the video (VOD).</para>
        /// <para>Is null if the video is not available or hasn’t been created yet from the live stream (see video_id).</para>
        /// <para>Note that there’s a delay between when a clip is created during a broadcast and when the offset is set. During the delay period, vod_offset is null. The delay is indeterminant but is typically minutes long.</para>
        /// </summary>
        [JsonPropertyName("vod_offset")]
        public int? VodOffset { get; set; }
    }
}
