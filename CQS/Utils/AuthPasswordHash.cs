using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace CQS.Utils
{
    public class AuthPasswordHash
    {
        public string PasswordHash(string password)
        {
            var salt = new byte[] { 0x20, 0x20, 0x20, 0x20 };

            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 32));

            return hashed;
        }
    }
}
