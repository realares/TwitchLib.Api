
namespace TwitchLib.Api.Core.Models.Undocumented.Chatters
{
    public class ChatterFormatted
    {
        public string Username { get; set; }
        public Enums.UserType UserType { get;  set; }

        public ChatterFormatted(string username, Enums.UserType userType)
        {
            Username = username;
            UserType = userType;
        }

        
    }
}
