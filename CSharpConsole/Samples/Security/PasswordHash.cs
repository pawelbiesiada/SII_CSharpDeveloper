using System;
using System.Security.Cryptography;
using System.Text;

namespace AdvancedCSharp.Samples.Security
{
    internal class PasswordHash
    {
        private static void Main()
        {
            var hash = ""; //hash previously saved
            var password = "password";
            var password2 = "password.";
            byte[] salt = GenerateSalt(); //salt adds complexity and randomness for hash algorithm

            Console.WriteLine("Password : " + password);
            Console.WriteLine("Salt : " + Convert.ToBase64String(salt));
            Console.WriteLine();

            var hashedPassword = GetHash(Encoding.UTF8.GetBytes(password));
            var hashedPassword2 = GetHash(Encoding.UTF8.GetBytes(password2));
            //var hashedPassword = GetHash(Encoding.UTF8.GetBytes(password), salt); //generate hash with salt

            Console.WriteLine("Salted Hash Password : " + Convert.ToBase64String(hashedPassword));
            Console.WriteLine("Salted Hash Password2 : " + Convert.ToBase64String(hashedPassword2));
            Console.WriteLine();

            Console.ReadLine();
            //google e.g. 5F4DCC3B5AA765D61D8327DEB882CF99
        }

        private static bool IsValid(string password, string hash)
        {
            var hashedPassword = GetHash(Encoding.UTF8.GetBytes(password));

            return hashedPassword.Equals(hash);
        }

        private static byte[] GetHash(byte[] text, byte[] salt = null)
        {
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hash = salt == null ? text : Combine(text, salt);
                var hashedBytes = sha256.ComputeHash(hash);
                return hashedBytes;
            }
        }

        private static byte[] GenerateSalt()
        {
            const int saltLength = 32;

            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[saltLength];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }

        private static byte[] Combine(byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);

            return ret;
        }
    }
}
