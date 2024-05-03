using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Extensions.SendExtensionPubSubMessage
{

    /// <summary>
    /// Sends a message to one or more viewers. You can send messages to a specific channel or to all channels where your extension is active. This endpoint uses the same mechanism as the send JavaScript helper function used to send <see cref="https://dev.twitch.tv/docs/extensions/reference#send"/> messages.
    /// Rate Limits: You may send a maximum of 100 messages per minute per combination of extension client ID and broadcaster ID.
    /// Authorization
    /// Requires a signed JSON Web Token (JWT) created by an Extension Backend Service (EBS). For signing requirements, see <see cref="https://dev.twitch.tv/docs/extensions/building/#signing-the-jwt" />. 
    /// The signed JWT must include the role, user_id, and exp fields (see JWT Schema <see cref="https://dev.twitch.tv/docs/extensions/reference/#jwt-schema"/> ) along with the channel_id and pubsub_perms fields.The role field must be set to external.
    /// To send the message to a specific channel, set the channel_id field in the JWT to the channel’s ID and set the pubsub_perms.send array to broadcast.
    /// </summary>
    public class SendExtensionPubSubMessageRequest
    {
        /// <summary>
        /// The target of the message. Possible values are:
        /// - broadcast
        /// - global
        /// - whisper-<user-id>
        /// If is_global_broadcast is true, you must set this field to global.
        /// The broadcast and global values are mutually exclusive; specify only one of them.
        /// </summary>
        [JsonPropertyName("target")]
        public string[] Target { get; set; } = null!;

        /// <summary>
        /// The ID of the broadcaster to send the message to. Don’t include this field if is_global_broadcast is set to true.
        /// </summary>
        [JsonPropertyName("broadcaster_id")]
        public string Broadcaster_id { get; set; } = null!;

        /// <summary>
        /// A Boolean value that determines whether the message should be sent to all channels where your extension is active. 
        /// Set to true if the message should be sent to all channels. The default is false.
        /// </summary>
        [JsonPropertyName("is_global_broadcast")]
        public bool Is_global_broadcast { get; set; }

        /// <summary>
        /// The message to send. The message can be a plain-text string or a string-encoded JSON object. 
        /// The message is limited to a maximum of 5 KB.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; } = null!;

        public static SendExtensionPubSubMessageRequest CreateBroadcast()
        {
            return new SendExtensionPubSubMessageRequest
            {
                Target = ["broadcast"],
                Is_global_broadcast = false,
            };
        }
    }

    public record SendExtensionPubSubMessageJWTAuth
    {
        [JsonPropertyName("exp")]
        public long Expire { get; set; }

        public SendExtensionPubSubMessageRequest jkj;

        /// <summary>
        /// The user's Twitch user ID. This is provided only for users who allow your extension to identify them. 
        /// There are no guarantees this will be available, as users can revoke an extension's ability to identify them at any time. 
        /// Users who revoke an extension's ability to identify them are issued a new opaque identifier.
        /// </summary>
        [JsonPropertyName("user_id")]
        public string User_id { get; set; }

        /// <summary>
        /// Type of user for whom this JWT has been signed. This is required. Valid values:
        /// </summary>
        [JsonPropertyName("role")]
        public ExtensionPubSubMessageRole Role { get; set; }

        /// <summary>
        /// Numeric ID of the channel from which your front-end is being served.
        /// </summary>
        [JsonPropertyName("channel_id")]
        public string Channel_Id { get; set; }


        /// <summary>
        /// Defines the ability of the token holder to send and listen to messages for your extension. 
        /// pubsub_perms contains two arrays: listen and send, which contain the topics the associated user is allowed to listen to and publish to, respectively.
        /// A wildcard/asterisk means the associated user can listen/publish to all topics associated with that extension/channel combination.
        /// A list of specific values means only the specified targets are allowed.
        /// If a permission is absent, it is equivalent to the empty listing: 
        /// there are no default allowed targets. When sending messages from the EBS, specify an asterisk as the send permission, 
        /// to allow the message to pass through the system.
        /// </summary>
        [JsonPropertyName("pubsub_perms")]
        public Perms Pubsub_perms { get; set; }
    }
    public record Perms
    {
        [JsonPropertyName("send")]
        public List<string> Send { get; set; }
    }

    public enum ExtensionPubSubMessageRole
    {
        /// <summary>
        /// The owner of the channel, who should have configuration rights.
        /// </summary>
        broadcaster,

        /// <summary>
        /// A viewer who has moderation rights on the channel. 
        /// This is provided only for users who allow your extension to identify them.
        /// </summary>
        moderator,

        /// <summary>
        /// A user watching the channel.
        /// </summary>
        viewer,

        /// <summary>
        /// The token is not from a Twitch token generator. 
        /// Your EBS should use this value to generate tokens when it broadcasts messages. 
        /// Multiple endpoints require this role.
        /// </summary>
        external,
    }
}
