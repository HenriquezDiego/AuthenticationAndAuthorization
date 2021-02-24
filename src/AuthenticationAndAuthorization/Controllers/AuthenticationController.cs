using AuthenticationAndAuthorization.DataAccess.Repositories;
using AuthenticationAndAuthorization.Models;
using AuthenticationAndAuthorization.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAndAuthorization.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthenticationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] UserInput model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "User or password invalid" });

            var token = _tokenService.CreateToken(user);
            user.Password = "";
            return new
            {
                user, token
            };
        }


        [Authorize]
        [HttpGet]
        [Route("auth")]
        public IActionResult GetAuth()
        {
            return Ok($"Authenticated - {User.Identity.Name}");
        }
        
        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public IActionResult Anonymous()
        {
            return Ok("You are Anonymous");
        }
        
        [HttpGet]
        [Route("tester")]
        [Authorize(Roles = "tester")]
        public IActionResult Tester()
        {
            return Ok($"{User.Identity.Name}");
        }
    }
}
