using System;

namespace TwitchLib.Api.Helix.Models.Moderation.BanUser
{
    public record TimeoutUser
    {
        public string UserId;
        public string Reason;
        public TimeSpan Duration; 
    }
}
