using System;

namespace TwitchLib.Api.Core.Exceptions
{
    public class NotFoundRequestException : Exception
    {
        /// <inheritdoc />
        /// <summary>Exception constructor</summary>
        public NotFoundRequestException(string apiData)
            : base(apiData)
        {
        }
    }

}
