using Microsoft.AspNetCore.Mvc;

namespace ArticlesPOSTGREDBCRUDOperations.Controllers
{
    public class AuthController : Controller
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Validate the user credential(this is just for test)
            //TODO: Move the validation code in DB, by having and read it
            if (model.Username == "test" && model.Password == "password") {
                string token = _tokenService.GenerateToken("1", model.Username);
                return Ok(new {Token = token });
            }
            return Unauthorized();
        }
    }
}
