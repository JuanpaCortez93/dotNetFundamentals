namespace _001_Basics.Models.Custom
{
    public class RefreshTokenRequest
    {
        public string? ExpiredToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
