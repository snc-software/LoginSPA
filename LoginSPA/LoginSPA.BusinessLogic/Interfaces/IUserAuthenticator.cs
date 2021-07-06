using LoginSPA.Models.DataStructures;

namespace LoginSPA.BusinessLogic.Interfaces
{
    public interface IUserAuthenticator
    {
        BasicUserDetails Authenticate(string username, string password);
    }
}