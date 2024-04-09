using _001_Basics.Models.Custom;

namespace _001_Basics.Services
{
    public interface IAuthorizationService
    {
        Task<ResponseAuthorization> GetBackToken(RequestAuthorization requestAuthorization);
        Task<ResponseAuthorization> GetBackRefreshToken(RefreshTokenRequest refreshTokenRequest, int userId);

    }
}
