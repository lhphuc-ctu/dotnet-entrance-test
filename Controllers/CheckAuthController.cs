using dotnet_entrance_test.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_entrance_test.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CheckAuthController : Controller
    {
        [HttpGet]
        [Route("check")]
        public IActionResult Get()
        {
            return Ok(new Response { Status = "Success", Message = "Authenticated!" });
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("checkAdmin")]
        public IActionResult GetAdmin()
        {
            return Ok(new Response { Status = "Success", Message = "Authenticated!" });
        }
    }
}
