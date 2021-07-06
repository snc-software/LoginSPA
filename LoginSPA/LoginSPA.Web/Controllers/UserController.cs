using LoginSPA.Persistence.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginSPA.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        readonly IUserRetriever _userRetriever;
        
        public UserController(IUserRetriever userRetriever)
        {
            _userRetriever = userRetriever;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userRetriever.RetrieveAll());
        }
    }
}