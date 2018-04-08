using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Security_Encrytions
{
    class AsymmetricAlgorithm
    {
        static void GenerateAsymmetricKeys(string[] args)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                string publicXML = rsa.ToXmlString(false);
                string privateXML = rsa.ToXmlString(true);
                Console.WriteLine("public key: {0}", publicXML);
                Console.WriteLine("private key: {0}", privateXML);
            }
        }
    }
}
