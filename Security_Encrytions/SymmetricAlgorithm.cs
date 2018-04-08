using System;
using System.IO;
using System.Security.Cryptography;

namespace Security_Encrytions
{
    class SymmetricAlgorithm
    {
        static void Main(string[] args)
        {            
            string original = "My secret data - to be protected over time";

            using (System.Security.Cryptography.SymmetricAlgorithm symmetricAlgorithm = new AesManaged())
            {
                byte[] encrypted = Encrypt(symmetricAlgorithm, original);
                string decrypted = Decrypt(symmetricAlgorithm, encrypted);

                Console.WriteLine("Original: {0}", original);
                Console.WriteLine("Encrypted: {0}", encrypted);
                Console.WriteLine("Decrypted: {0}", decrypted);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Encrypt a given message, provided with key and IV
        /// </summary>
        /// <param name="aesAlg"></param>
        /// <param name="plainText"></param>
        /// <returns></returns>
        static byte[] Encrypt(System.Security.Cryptography.SymmetricAlgorithm aesAlg, string plainText)
        {
            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {               
                using (StreamWriter swEncrypt = new StreamWriter(new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)))
                {
                    swEncrypt.Write(plainText);
                }
                return msEncrypt.ToArray();                
            }
        }

        /// <summary>
        /// Method to decrypt the ciphertext, with the symmetric key passed
        /// </summary>
        /// <param name="aesAlg"></param>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        static string Decrypt(System.Security.Cryptography.SymmetricAlgorithm aesAlg, byte[] cipherText)
        {
            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (StreamReader srDecrypt = new StreamReader(
                    new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }
}
