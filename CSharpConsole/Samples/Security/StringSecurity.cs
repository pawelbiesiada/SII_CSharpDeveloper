using System;
using System.Security;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace AdvancedCSharp.Samples.Security
{
    //You should never assign secureString as plain text to a variable otherwise it will be cashed.
    class StringSecurity
    {
        static void Main()
        {
            var password = new SecureString();
            ConsoleKeyInfo key;

            Console.Write("Enter password: ");
            do
            {
                key = Console.ReadKey(true);

                // Append the character to the password.
                if (key.Key != ConsoleKey.Enter)
                {
                    password.AppendChar(key.KeyChar);
                    Console.Write("*");
                }
                // Exit if Enter key is pressed.
            } while (key.Key != ConsoleKey.Enter);
            password.MakeReadOnly();
            Console.WriteLine();

            //Console.WriteLine("UnencryptedString: {0}" ,SecureStringToString(password));

            try
            {
                Process.Start("notepad.exe", "pbiesiada", password, "SIIPOLSKA");
            }
            catch (Win32Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                password.Dispose();
            }

            Console.ReadKey();
        }

        static string SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

    }
}
