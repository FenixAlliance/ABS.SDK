using System;
using System.Security.Cryptography;
using System.Text;
using FenixAlliance.Models.DTOs.Authorization;
using Microsoft.AspNetCore.WebUtilities;

namespace FenixAlliance.SDK.Helpers
{
    public class SecurityHelpers
    {
        public static Tuple<string, string> GenerateKeyPair()
        {
            string PublicKey = string.Empty;
            string PrivateKey = string.Empty;
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    //Save the public key information to an RSAParameters structure.  
                    RSAParameters rsaKeyInfo = rsa.ExportParameters(false);
                    PublicKey = StringHelpers.Base64Encode(rsa.ToXmlString(false));
                    PrivateKey = StringHelpers.Base64Encode(rsa.ToXmlString(true));
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }

            return new Tuple<string, string>(PublicKey, PrivateKey);
        }

        public static bool VerifyPayload(JsonWebTokenPayload OriginalPayload, string PayloadSignature, RSAParameters publicKey)
        {
            bool success = false;
            byte[] bytesToVerify = Encoding.UTF8.GetBytes(Serialize.ToJson(OriginalPayload));
            var signedBytes = WebEncoders.Base64UrlDecode(PayloadSignature);

            using (var RSA = new RSACryptoServiceProvider())
            {
                try
                {
                    RSA.ImportParameters(publicKey);
                    success = RSA.VerifyData(bytesToVerify, CryptoConfig.MapNameToOID("SHA512"), signedBytes);
                }
                catch (CryptographicException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    RSA.PersistKeyInCsp = false;
                }
            }
            return success;
        }

        public static string SignPayload(JsonWebTokenPayload Payload, RSAParameters privateKey)
        {
            //// The array to store the signed message in bytes
            byte[] signedBytes;
            using (var RSA = new RSACryptoServiceProvider())
            {
                //// Write the message to a byte array using UTF8 as the encoding.
                var encoder = new UTF8Encoding();
                byte[] originalData = encoder.GetBytes(Serialize.ToJson(Payload));

                try
                {
                    //// Import the private key used for signing the message
                    RSA.ImportParameters(privateKey);

                    //// Sign the data, using SHA512 as the hashing algorithm 
                    signedBytes = RSA.SignData(originalData, CryptoConfig.MapNameToOID("SHA512"));
                }
                catch (CryptographicException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
                finally
                {
                    //// Set the keycontainer to be cleared when rsa is garbage collected.
                    RSA.PersistKeyInCsp = false;
                }
            }
            //// Convert the a base64 string before returning
            return WebEncoders.Base64UrlEncode(signedBytes);
        }

        static public byte[] RSAEncrypt(byte[] DataToEncrypt, string RSAPublicKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Import the RSA Key information. This only needs
                    //toinclude the public key information.
                    RSA.FromXmlString(RSAPublicKeyInfo);

                    //Encrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            //Catch and log CryptographicException  
            catch (CryptographicException e)
            {
                // TODO: LOG
                return null;
            }

        }

        static public byte[] RSADecrypt(byte[] DataToDecrypt, string RSAPrivateKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    // Import the RSA Private Key information. 
                    RSA.FromXmlString(RSAPrivateKeyInfo);

                    //Decrypt the passed byte array and specify OAEP padding.  
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                // TODO: LOG
                Console.WriteLine(e.ToString());
                return null;
            }

        }


        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder StringBuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    StringBuilder.Append(bytes[i].ToString("x2"));
                }
                return StringBuilder.ToString();
            }
        }
    }
}
