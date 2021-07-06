using LoginSPA.BusinessLogic.Interfaces;
using LoginSPA.Models.DataStructures;
using LoginSPA.Persistence.Interfaces;

namespace LoginSPA.BusinessLogic
{
    public class UserAuthenticator : IUserAuthenticator
    {
        readonly IUserRetriever _userRetriever;
        readonly IPasswordChecker _passwordChecker;
        
        public UserAuthenticator(IUserRetriever userRetriever,
            IPasswordChecker passwordChecker)
        {
            _userRetriever = userRetriever;
            _passwordChecker = passwordChecker;
        }

        public BasicUserDetails Authenticate(string username, string password)
        {
            var user = _userRetriever.RetrieveByUsername(username);
            return null;
        }
    }
}