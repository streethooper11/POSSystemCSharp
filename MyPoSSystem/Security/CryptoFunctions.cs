using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MyPoSSystem.Security
{
    // Source: https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-7.0
    public class CryptoFunctions
    {
        private const int AES_IV_SIZE = 16;

        public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            byte[] encrypted;
            byte[] result;

            // Create an Aes object
            // with the specified key
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.GenerateIV();
                aesAlg.Padding = PaddingMode.PKCS7;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }

                result = new byte[AES_IV_SIZE + encrypted.Length];
                Buffer.BlockCopy(aesAlg.IV, 0, result, 0, AES_IV_SIZE);
                Buffer.BlockCopy(encrypted, 0, result, AES_IV_SIZE, encrypted.Length);
            }

            // Return the encrypted bytes from the memory stream.
            return result;
        }

        public static string DecryptStringFromBytes_Aes(byte[] cipherBytes, byte[] Key)
        {
            // Check arguments.
            if (cipherBytes == null || cipherBytes.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");

            // Create an Aes object
            // with the specified key and IV.
            byte[] iv = new byte[AES_IV_SIZE];
            Buffer.BlockCopy(cipherBytes, 0, iv, 0, AES_IV_SIZE);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = iv;
                aesAlg.Padding = PaddingMode.PKCS7;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                byte[] cipherBytesNoIV = new byte[cipherBytes.Length - AES_IV_SIZE];
                Buffer.BlockCopy(cipherBytes, AES_IV_SIZE, cipherBytesNoIV, 0, cipherBytes.Length - AES_IV_SIZE);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherBytesNoIV))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        public static byte[] GetHMACFromText(byte[] text, byte[] key)
        {
            using (HMACSHA512 hmac = new HMACSHA512(key))
            {
                return hmac.ComputeHash(text);
            }
        }

        public static byte[] GetByteArrayFromString(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        public static string GetStringFromByteArray(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
