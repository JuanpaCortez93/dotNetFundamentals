using _001_Basics.Models.Custom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace _001_Basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {

        private readonly _001_Basics.Services.IAuthorizationService _authorizationService;

        public UserAuthenticationController(_001_Basics.Services.IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost("authentication")]
        public async Task<IActionResult> UserAuthentication([FromBody] RequestAuthorization requestAuthorization)
        {
            var authenticationResult = await _authorizationService.GetBackToken(requestAuthorization);
            if(authenticationResult == null) return Unauthorized();

            return Ok(authenticationResult);
        }

        [HttpPost("refreshAuthentication")]
        public async Task<IActionResult> RefreshUserAuthentication([FromBody] RefreshTokenRequest refreshTokenRequest)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var isValidToken = tokenHandler.ReadJwtToken(refreshTokenRequest.ExpiredToken);

            if (isValidToken.ValidTo > DateTime.UtcNow) return BadRequest();

            string userId = isValidToken.Claims.First(token => token.Type == JwtRegisteredClaimNames.NameId).Value.ToString();

            var responseAuthorization = await _authorizationService.GetBackRefreshToken(refreshTokenRequest, int.Parse(userId));

            if(responseAuthorization.Result) 
                return Ok(responseAuthorization);
            else
                return BadRequest(responseAuthorization);

        }
    }
}
