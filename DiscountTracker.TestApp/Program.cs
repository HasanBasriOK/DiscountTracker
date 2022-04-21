using System;
using DiscountTracker.Common.Constants;

namespace DiscountTracker.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var encryptedPassword= Utilities.EncryptionHelpers.Encryption.Encrypt("123456", EncryptionConstants.ClientEncryptionKey);
            Console.WriteLine(encryptedPassword);
            Console.Read();
            //CLGJB5r96IYaMRmzJqhm2g==
        }
    }
}
