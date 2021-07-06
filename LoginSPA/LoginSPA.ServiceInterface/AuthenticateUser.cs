using LoginSPA.Models.DataStructures;

namespace LoginSPA.ServiceInterface
{
    public class AuthenticateUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticateUserResponse
    {
        public BasicUserDetails User { get; set; }
        public string Token { get; set; }
    }
}