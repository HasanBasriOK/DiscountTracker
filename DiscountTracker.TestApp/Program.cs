using System;
using DiscountTracker.Utilities;

namespace DiscountTracker.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var encryptedPassword= Utilities.EncryptionHelpers.Encryption.Encrypt("12345", Constants.ClientEncryptionKey);
            Console.WriteLine(encryptedPassword);
            Console.Read();
            //CLGJB5r96IYaMRmzJqhm2g==
        }
    }
}
