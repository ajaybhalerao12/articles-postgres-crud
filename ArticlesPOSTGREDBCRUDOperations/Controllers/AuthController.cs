using ArticlesPOSTGREDBCRUDOperations.Data;
using ArticlesPOSTGREDBCRUDOperations.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ArticlesPOSTGREDBCRUDOperations.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDBContext _context;
        private readonly TokenService _tokenService;

        public AuthController(AppDBContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {            
            var user = _context.Users
                .SingleOrDefault(u => u.UserName == model.Username);
            
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))                
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }
            var token = _tokenService.GenerateToken(user.Id.ToString(), user.UserName);
            return Ok(new {Token = token, message ="Login Successfull"});
        }
    }
}
