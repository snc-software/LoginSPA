using System.Collections.Generic;
using LoginSPA.Models;

namespace LoginSPA.Persistence.Interfaces
{
    public interface IUserRetriever
    {
        UserModel RetrieveByUsername(string username);
        List<UserModel> RetrieveAll();
    }
}