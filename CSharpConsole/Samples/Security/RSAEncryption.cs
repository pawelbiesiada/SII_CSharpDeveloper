using System;
using System.Text;
using System.Security.Cryptography;

namespace AdvancedCSharp.Samples.Security
{
    class RSAEncryption
    {
        static void Main()
        {
            var password = "P@$$w0rd";

            using (var rsa = new RSACryptoServiceProvider())
            {
                var encrypted = Encrypt(password, rsa.ExportParameters(false));
                var decrypted = Decrypt(encrypted, rsa.ExportParameters(true));
                
                Console.WriteLine("Password {0}", password);
                Console.WriteLine("Encrypted password {0}", Encoding.UTF8.GetString(encrypted));
                Console.WriteLine("Decrypted password {0}", decrypted);
            }

            Console.ReadKey();
        }

        static byte[] Encrypt(string password, RSAParameters parameters)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                var data = new UnicodeEncoding().GetBytes(password);
                rsa.ImportParameters(parameters);
                var encrypted = rsa.Encrypt(data, false);

                return encrypted;
            }
        }
        static string Decrypt(byte[] encrypted, RSAParameters parameters)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(parameters);
                var password = rsa.Decrypt(encrypted, false);

                return new UnicodeEncoding().GetString(password);
            }
        }
    }
}
