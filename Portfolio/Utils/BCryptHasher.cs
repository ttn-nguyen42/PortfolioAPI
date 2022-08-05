using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Portfolio.Utils
{
    public static class KeyHasher
    {
        public static string Hash(string key)
        {
            byte[] salts = new byte[key.Length];
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: key,
                salt: salts,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10,
                numBytesRequested: 128 / 8
           ));
        }
    }
}
