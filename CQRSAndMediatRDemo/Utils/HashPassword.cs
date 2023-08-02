using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace CQRSAndMediatRDemo.Utils
{
    public class HashPassword
    {
        public static string HassPass(string password)
        {
            byte[] salt = Encoding.UTF8.GetBytes("hello");
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
               password: password,
               salt: salt,
               prf: KeyDerivationPrf.HMACSHA256,
               iterationCount: 100000,
               numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
