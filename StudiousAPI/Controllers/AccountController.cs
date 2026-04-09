using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace StudiousAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public IActionResult Welcome()
        {
            if(User.Identity == null || !User.Identity.IsAuthenticated)
            {
                return Ok("You are NOT authenicated.");
            }

            return Ok("You are authenicated.");
        }
    }
}
