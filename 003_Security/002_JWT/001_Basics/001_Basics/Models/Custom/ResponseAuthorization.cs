namespace _001_Basics.Models.Custom
{
    public class ResponseAuthorization
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }
    }
}
