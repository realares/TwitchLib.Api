using System;

namespace TwitchLib.Api.Core.Exceptions
{
    public class TooEarlyException : Exception
    {
        /// <inheritdoc />
        /// <summary>Exception constructor</summary>
        public TooEarlyException(string data)
            : base(data)
        {
        }
    }
}