using System;

namespace TwitchLib.Api.Core.Exceptions
{
    public class UnauthorizedRequestException : Exception
    {
        /// <inheritdoc />
        /// <summary>Exception constructor</summary>
        public UnauthorizedRequestException(string? apiData)
            : base(apiData)
        {
        }
    }

}
