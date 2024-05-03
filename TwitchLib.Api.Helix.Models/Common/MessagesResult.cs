using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TwitchLib.Api.Helix.Models.Common
{
    public record DetailMessagesResult
    {
        public string Content { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }

    }
}
