using System;

namespace TwitchLib.Api.Core.Exceptions
{
    public class ConflictRequestException : Exception
    {
        /// <inheritdoc />
        /// <summary>Exception constructor</summary>
        public ConflictRequestException(string? apiData)
            : base(apiData)
        {
        }
    }

}
