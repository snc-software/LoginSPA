using LoginSPA.BusinessLogic.Interfaces;
using LoginSPA.Persistence.Interfaces;

namespace LoginSPA.BusinessLogic
{
    public class UserAuthenticator : IUserAuthenticator
    {
        IUserRetriever _userRetriever;
        IPasswordChecker _passwordChecker;
        
        public UserAuthenticator(IUserRetriever userRetriever,
            IPasswordChecker passwordChecker)
        {
            _userRetriever = userRetriever;
            _passwordChecker = passwordChecker;
        }
    }
}