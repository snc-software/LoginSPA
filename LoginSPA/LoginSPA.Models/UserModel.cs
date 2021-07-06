using LoginSPA.Models.DataStructures;

namespace LoginSPA.Models
{
    public class UserModel : BasicUserDetails
    {
        public string Hash { get; set; }
        
        public string HashedPassword { get; set; }
    }
}