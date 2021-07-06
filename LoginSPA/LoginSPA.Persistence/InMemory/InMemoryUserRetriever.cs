using System.Collections.Generic;
using LoginSPA.Models;
using LoginSPA.Persistence.Interfaces;

namespace LoginSPA.Persistence.InMemory
{
    public class InMemoryUserRetriever : IUserRetriever
    {
        public UserModel RetrieveByUsername()
        {
            throw new System.NotImplementedException();
        }

        public List<UserModel> RetrieveAll()
        {
            throw new System.NotImplementedException();
        }
    }
}