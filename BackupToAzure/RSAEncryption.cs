using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RSAAlgorithm
{
    public class RSAEncryption
    {

        public static RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        public static UTF8Encoding encoder = new UTF8Encoding();
        //The RSAParameters can contain private and public key by using RSACryptoServiceProvider 
        //class and method is ExportParameter.
        public static RSAParameters privateKey;
        public static RSAParameters publicKey;

        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        static public byte[] Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static byte[] Encrypt(byte[] byteText)
        {
            try
            {
                byte[] encryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                //Encrypt the passed byte array and specify OAEP padding. 
                //OAEP padding is only available on Microsoft Windows XP or
                //later. 

                encryptedData = rsa.Encrypt(byteText, RSAEncryptionPadding.Pkcs1);

                return encryptedData;
            }

            //Catch and display a CryptographicException 
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static byte[] RSADecrypt(byte[] DataToDecrypt, ref string decrpytedText)
        {
            try
            {
                byte[] decryptedData;
                //Create a new instance of RSACryptoServiceProvider.           
                //Import the RSA Key information. This needs
                //to include the private key information
                //Decrypt the passed byte array and specify OAEP padding. 
                //OAEP padding is only available on Microsoft Windows XP or
                //later. 

                decryptedData = rsa.Decrypt(DataToDecrypt, RSAEncryptionPadding.Pkcs1);

                decrpytedText = encoder.GetString(decryptedData);

                return decryptedData;
            }

            //Catch and display a CryptographicException 
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static void GenerateKey()
        {
            rsa.PersistKeyInCsp = false;
            publicKey = rsa.ExportParameters(false);
            privateKey = rsa.ExportParameters(true);
        }

    }
}
