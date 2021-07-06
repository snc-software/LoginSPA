using System.Collections.Generic;
using LoginSPA.Models;
using LoginSPA.Persistence.Interfaces;

namespace LoginSPA.Persistence
{
    public class PersistenceUserRetriever : IUserRetriever
    {
        public UserModel RetrieveByUsername(string username)
        {
            throw new System.NotImplementedException();
        }

        public List<UserModel> RetrieveAll()
        {
            throw new System.NotImplementedException();
        }
    }
}