﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DiscountTracker.Utilities.EncryptionHelpers
{
    public class Encryption
    {

        static string initializeVector = "TracDiscountTrac";

        public static string Encrypt(string plainText, string key)
        {
            var iv = Encoding.UTF8.GetBytes(initializeVector);

            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            using (var streamWriter = new StreamWriter(cryptoStream))
            {
                streamWriter.Write(plainText);
            }

            var array = memoryStream.ToArray();

            return Convert.ToBase64String(array);
        }

        public static string Decrypt(string cipherText, string key)
        {
            var iv = Encoding.UTF8.GetBytes(initializeVector);
            var buffer = Convert.FromBase64String(cipherText);

            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using var memoryStream = new MemoryStream(buffer);
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using var streamReader = new StreamReader(cryptoStream);
            return streamReader.ReadToEnd();
        }


    }
}
