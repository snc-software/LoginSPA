using System.Collections.Generic;
using LoginSPA.Models;

namespace LoginSPA.Persistence.Interfaces
{
    public interface IUserRetriever
    {
        UserModel RetrieveByUsername();
        List<UserModel> RetrieveAll();
    }
}