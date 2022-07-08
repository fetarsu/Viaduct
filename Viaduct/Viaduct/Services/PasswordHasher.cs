using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Viaduct.Services
{
    internal static class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;

        public static string Hash(string password, int iterations)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt;
                rng.GetBytes(salt = new byte[SaltSize]);
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
                {
                    var hash = pbkdf2.GetBytes(HashSize);
                    var hashBytes = new byte[SaltSize + HashSize];
                    Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                    Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);
                    var base64Hash = Convert.ToBase64String(hashBytes);

                    return base64Hash;
                }
            }

        }

        public static string Hash(string password)
        {
            return Hash(password, 15829);
        }

        public static bool Verify(string password, string hashedPassword)
        {
            var hashBytes = Convert.FromBase64String(hashedPassword);
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 15829))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);

                for (var i = 0; i < HashSize; i++)
                {
                    if (hashBytes[i + SaltSize] != hash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
