using _000_Fundamentals.Constants;
using _000_Fundamentals.DTOs;
using _000_Fundamentals.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _000_Fundamentals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var currentUser = GetCurrentUser();
            return Ok(currentUser);
        }

        [HttpPost]
        public IActionResult Login(LoginUsers loginUsers)
        {

            var user = Authenticate(loginUsers);

            if(user != null)
            {
                var token = GenerateToken(user);
                return Ok(token);
            }

            return NotFound("User not found");
        }

        private Users Authenticate(LoginUsers userLogin)
        {
            var currentUser = UserConstants.Users.FirstOrDefault(user => user.UserName.ToUpper() == userLogin.UserName.ToUpper() && user.Password == userLogin.Password);

            if(currentUser != null) 
            {
                return currentUser;
            }

            return null;
        }

        private string GenerateToken(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["ConnectionStrings:JWTKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Crear los claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Rol),
                new Claim("idEmpresa", "111")
            };

            //Crear el token
            var token = new JwtSecurityToken(

                    _config["ConnectionStrings:JWTIssuer"],
                    _config["ConnectionStrings:JWTAudience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(1),
                    signingCredentials: credentials

                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Users GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if(identity != null)
            {
                var userClaims = identity.Claims;
                return new Users
                {
                    UserName = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value,
                    FirstName = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.GivenName)?.Value,
                    LastName = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.Surname)?.Value,
                    Rol = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}
