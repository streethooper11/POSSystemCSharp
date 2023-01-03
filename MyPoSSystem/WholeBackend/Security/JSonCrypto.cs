using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyPoSSystem.WholeBackend.Security
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
            Buffer.BlockCopy(initialKey, 0, key2, KEY_SIZE, KEY_SIZE);

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
        public static string DecryptJson(string json)
        {
            byte[] initialKey = CreateInitialKey(); // 64 bytes

            byte[] key1 = new byte[KEY_SIZE];
            byte[] key2 = new byte[KEY_SIZE];

            Buffer.BlockCopy(initialKey, 0, key1, 0, KEY_SIZE);
            Buffer.BlockCopy(initialKey, 0, key2, KEY_SIZE, KEY_SIZE);

            byte[] calcHMAC = CryptoFunctions.GetHMACFromText(CryptoFunctions.GetByteArrayFromString(json), key2);
            byte[] textHMAC = CryptoFunctions.GetByteArrayFromString(json.Substring(json.Length - HMAC_LENGTH));

            if (textHMAC.Length == calcHMAC.Length &&
                calcHMAC.SequenceEqual(textHMAC))
            {
                return CryptoFunctions.DecryptStringFromBytes_Aes(json, key1);
            }
            else
            {
                throw new HMACMismatchException("HMAC does not match");
            }
        }

        public static string DecryptJson(byte[] json)
        {
            return DecryptJson(CryptoFunctions.GetStringFromByteArray(json));
        }

        private static byte[] CreateInitialKey()
        {
            string initialKey = "usf4";
            initialKey += "pstreet11";
            initialKey += "gen5fst.mkh";
            initialKey += "xtatsu5f";
            initialKey += "goukene";

            initialKey = initialKey.Substring(0, 4) + initialKey.Substring(13, 11) + initialKey.Substring(4, 9) + initialKey.Substring(32) + initialKey.Substring(24, 8);

            return CryptoFunctions.GetByteArrayFromString(initialKey);
        }
    }
}
