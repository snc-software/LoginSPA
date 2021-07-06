using LoginSPA.BusinessLogic.Interfaces;
using LoginSPA.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace LoginSPA.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        IUserAuthenticator _userAuthenticator;
        
        public AuthenticateController(IUserAuthenticator userAuthenticator)
        {
            _userAuthenticator = userAuthenticator;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] AuthenticateUserRequest request)
        {
            return Ok();
        }
    }
}