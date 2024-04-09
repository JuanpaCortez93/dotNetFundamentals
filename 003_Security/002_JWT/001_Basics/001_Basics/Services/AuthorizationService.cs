using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using _001_Basics.Models;
using _001_Basics.Models.Custom;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace _001_Basics.Services
{
    public class AuthorizationService : IAuthorizationService
    {

        private readonly DbPruebasJwtContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthorizationService(DbPruebasJwtContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }


        private string TokenGenerator(string userId)
        {
            var key = _configuration.GetConnectionString("JwtJey");
            var keyBytes = Encoding.ASCII.GetBytes(key);
            
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId));

            var credentialsToken = new SigningCredentials (
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature                
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = credentialsToken
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string createdToken = tokenHandler.WriteToken(tokenConfig);

            return createdToken;
        }

        private string RefreshTokenGenerator()
        {
            var byteArray = new byte[64];
            var refreshToken = "";

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(byteArray);
                refreshToken = Convert.ToBase64String(byteArray);
            }

            return refreshToken;

        }

        private async Task<ResponseAuthorization> SaveRefreshTokenHistory(int userId, string token, string refreshToken)
        {
            var refreshTokenHistory = new RefreshTokenHistorial
            {
                UserId = userId,
                Token = token,
                RefreshToken = refreshToken,
                ExpirationDate = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow.AddMinutes(2)
            };

            await _dbContext.RefreshTokenHistorials.AddAsync(refreshTokenHistory);
            await _dbContext.SaveChangesAsync();

            return new ResponseAuthorization
            {
                Token = token, RefreshToken = refreshToken, Result = true, Message = "Ok"
            };
        }

        public async Task<ResponseAuthorization> GetBackToken(RequestAuthorization requestAuthorization)
        {
            var userFound = await _dbContext.Users.FirstOrDefaultAsync(user => user.Username == requestAuthorization.Username && user.Upassword == requestAuthorization.UPassword);

            if (userFound == null) return null;

            string createdToken = TokenGenerator(userFound.Id.ToString());

            string refreshTokenCreated = RefreshTokenGenerator();

            return await SaveRefreshTokenHistory(userFound.Id, createdToken, refreshTokenCreated);


            //return new ResponseAuthorization
            //{
            //    Token = createdToken,
            //    Result = true,
            //    Message = "Ok"
            //};


        }

        public async Task<ResponseAuthorization> GetBackRefreshToken(RefreshTokenRequest refreshTokenRequest, int userId)
        {

            var refreshToken = await _dbContext.RefreshTokenHistorials.FirstOrDefaultAsync(
                token => token.Token == refreshTokenRequest.ExpiredToken
                &&
                token.RefreshToken == refreshTokenRequest.RefreshToken
                &&
                token.UserId == userId
            );

            if (refreshToken == null) return new ResponseAuthorization { Result = false, Message = "Refresh Token doesn't exist" };

            var refreshTokenCreado = RefreshTokenGenerator();
            var tokenCreado = TokenGenerator(userId.ToString());

            return await SaveRefreshTokenHistory(userId, tokenCreado, refreshTokenCreado);

        }
    }
}
