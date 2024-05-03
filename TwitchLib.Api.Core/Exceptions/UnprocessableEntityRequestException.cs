using System;

namespace TwitchLib.Api.Core.Exceptions
{
    public class UnprocessableEntityRequestException : Exception
    {
        /// <inheritdoc />
        /// <summary>Exception constructor</summary>
        public UnprocessableEntityRequestException(string apiData)
            : base(apiData)
        {
        }
    }

}
