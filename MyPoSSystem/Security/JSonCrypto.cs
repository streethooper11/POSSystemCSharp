using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using MyPoSSystem.Constants;

namespace MyPoSSystem.Security
{
    public class JSonCrypto
    {
        private const int KEY_SIZE = 32;
        private const int HMAC_LENGTH = 64;

        /**
         * Idea: Encrypt-then-MAC
         * 1. HMAC (SHA3-512) a certain string, to get 64 bytes
         * 2. Split into 2 byte arrays, 32 bytes each
         * 3. Use first 32 bytes for encryption (AES-256)
         * 4. Use latter 32 bytes for HMAC (SHA3-256)
         * 5. Encrypt the plaintext
         * 6. HMAC the ciphertext
         * 7. Append HMAC to the end of ciphertext
         * 8. Return result
         */
        public static byte[] EncryptJson(string json)
        {
            byte[] initialKey = CreateInitialKey(); // 64 bytes

            byte[] key1 = new byte[KEY_SIZE];
            byte[] key2 = new byte[KEY_SIZE];

            Buffer.BlockCopy(initialKey, 0, key1, 0, KEY_SIZE);
            Buffer.BlockCopy(initialKey, KEY_SIZE, key2, 0, KEY_SIZE);

            byte[] ciphertext = CryptoFunctions.EncryptStringToBytes_Aes(json, key1);
            byte[] hmac = CryptoFunctions.GetHMACFromText(ciphertext, key2);

            byte[] result = new byte[ciphertext.Length + hmac.Length];

            Buffer.BlockCopy(ciphertext, 0, result, 0, ciphertext.Length);
            Buffer.BlockCopy(hmac, 0, result, ciphertext.Length, hmac.Length);

            return result;
        }

        /**
         * Decrypt Encrypt-then-MAC; also test integrity
         * 1. Split into ciphertext and HMAC
         * 2. HMAC (SHA3-512) a certain string, to get 64 bytes
         * 3. Split into 2 byte arrays, 32 bytes each
         * 4. Use first 32 bytes for encryption (AES-256)
         * 5. Use latter 32 bytes for HMAC (SHA3-256)
         * 6. HMAC the ciphertext
         * 7. If the two HMACs do not match, throw exception
         * 8. If the two HMACs match, decrypt the plaintext and return the result
         */
        public static string DecryptJson(byte[] json)
        {
            byte[] initialKey = CreateInitialKey(); // 64 bytes

            byte[] key1 = new byte[KEY_SIZE];
            byte[] key2 = new byte[KEY_SIZE];

            Buffer.BlockCopy(initialKey, 0, key1, 0, KEY_SIZE);
            Buffer.BlockCopy(initialKey, KEY_SIZE, key2, 0, KEY_SIZE);

            byte[] cipherBytes = new byte[json.Length - HMAC_LENGTH];
            byte[] textHMAC = new byte[HMAC_LENGTH];

            Buffer.BlockCopy(json, 0, cipherBytes, 0, json.Length - HMAC_LENGTH);
            Buffer.BlockCopy(json, json.Length - HMAC_LENGTH, textHMAC, 0, HMAC_LENGTH);

            byte[] calcHMAC = CryptoFunctions.GetHMACFromText(cipherBytes, key2);

            if (textHMAC.Length == calcHMAC.Length &&
                calcHMAC.SequenceEqual(textHMAC))
            {
                return CryptoFunctions.DecryptStringFromBytes_Aes(cipherBytes, key1);
            }
            else
            {
                throw new HMACMismatchException("HMAC does not match");
            }
        }

        private static byte[] CreateInitialKey()
        {
            return CryptoFunctions.GetByteArrayFromString(SettingConst.CreateKey());
        }
    }
}
