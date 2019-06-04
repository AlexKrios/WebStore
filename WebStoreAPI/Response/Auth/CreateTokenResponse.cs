using System;

namespace WebStoreAPI.Response.Auth
{
    public class CreateTokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TokenExpiration { get; set; }
    }
}
