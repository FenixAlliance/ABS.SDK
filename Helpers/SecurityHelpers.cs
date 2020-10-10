using System;
using System.IO;
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

        // Encrypt a file using a public key.
        private static void EncryptFile(string inFile,string EncriptionFolder, RSACryptoServiceProvider rsaPublicKey)
        {
            using (AesManaged aesManaged = new AesManaged())
            {
                // Create instance of AesManaged for
                // symetric encryption of the data.
                aesManaged.KeySize = 256;
                aesManaged.BlockSize = 128;
                aesManaged.Mode = CipherMode.CBC;
                using (ICryptoTransform transform = aesManaged.CreateEncryptor())
                {
                    RSAPKCS1KeyExchangeFormatter keyFormatter = new RSAPKCS1KeyExchangeFormatter(rsaPublicKey);
                    byte[] keyEncrypted = keyFormatter.CreateKeyExchange(aesManaged.Key, aesManaged.GetType());

                    // Create byte arrays to contain
                    // the length values of the key and IV.
                    byte[] LenK = new byte[4];
                    byte[] LenIV = new byte[4];

                    int lKey = keyEncrypted.Length;
                    LenK = BitConverter.GetBytes(lKey);
                    int lIV = aesManaged.IV.Length;
                    LenIV = BitConverter.GetBytes(lIV);

                    // Write the following to the FileStream
                    // for the encrypted file (outFs):
                    // - length of the key
                    // - length of the IV
                    // - ecrypted key
                    // - the IV
                    // - the encrypted cipher content

                    int startFileName = inFile.LastIndexOf("\\") + 1;
                    // Change the file's extension to ".enc"
                    string outFile = EncriptionFolder + inFile.Substring(startFileName, inFile.LastIndexOf(".") - startFileName) + ".enc";
                    Directory.CreateDirectory(EncriptionFolder);

                    using (FileStream outFs = new FileStream(outFile, FileMode.Create))
                    {

                        outFs.Write(LenK, 0, 4);
                        outFs.Write(LenIV, 0, 4);
                        outFs.Write(keyEncrypted, 0, lKey);
                        outFs.Write(aesManaged.IV, 0, lIV);

                        // Now write the cipher text using
                        // a CryptoStream for encrypting.
                        using (CryptoStream outStreamEncrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                        {

                            // By encrypting a chunk at
                            // a time, you can save memory
                            // and accommodate large files.
                            int count = 0;
                            int offset = 0;

                            // blockSizeBytes can be any arbitrary size.
                            int blockSizeBytes = aesManaged.BlockSize / 8;
                            byte[] data = new byte[blockSizeBytes];
                            int bytesRead = 0;

                            using (FileStream inFs = new FileStream(inFile, FileMode.Open))
                            {
                                do
                                {
                                    count = inFs.Read(data, offset, blockSizeBytes);
                                    offset += count;
                                    outStreamEncrypted.Write(data, 0, count);
                                    bytesRead += count;
                                }
                                while (count > 0);
                                inFs.Close();
                            }
                            outStreamEncrypted.FlushFinalBlock();
                            outStreamEncrypted.Close();
                        }
                        outFs.Close();
                    }
                }
            }
        }


        // Decrypt a file using a private key.
        private static void DecryptFile(string inFile,string EncriptionFolder, string DecriptionFolder, string EncryptedFileExtension, RSACryptoServiceProvider rsaPrivateKey)
        {

            // Create instance of AesManaged for
            // symetric decryption of the data.
            using (AesManaged aesManaged = new AesManaged())
            {
                aesManaged.KeySize = 256;
                aesManaged.BlockSize = 128;
                aesManaged.Mode = CipherMode.CBC;

                // Create byte arrays to get the length of
                // the encrypted key and IV.
                // These values were stored as 4 bytes each
                // at the beginning of the encrypted package.
                byte[] LenK = new byte[4];
                byte[] LenIV = new byte[4];

                // Consruct the file name for the decrypted file.
                string outFile = DecriptionFolder + inFile.Substring(0, inFile.LastIndexOf(".")) + "." + EncryptedFileExtension;

                // Use FileStream objects to read the encrypted
                // file (inFs) and save the decrypted file (outFs).
                using (FileStream inFs = new FileStream(EncriptionFolder + inFile, FileMode.Open))
                {

                    inFs.Seek(0, SeekOrigin.Begin);
                    inFs.Seek(0, SeekOrigin.Begin);
                    inFs.Read(LenK, 0, 3);
                    inFs.Seek(4, SeekOrigin.Begin);
                    inFs.Read(LenIV, 0, 3);

                    // Convert the lengths to integer values.
                    int lenK = BitConverter.ToInt32(LenK, 0);
                    int lenIV = BitConverter.ToInt32(LenIV, 0);

                    // Determine the start postition of
                    // the ciphter text (startC)
                    // and its length(lenC).
                    int startC = lenK + lenIV + 8;
                    int lenC = (int)inFs.Length - startC;

                    // Create the byte arrays for
                    // the encrypted AesManaged key,
                    // the IV, and the cipher text.
                    byte[] KeyEncrypted = new byte[lenK];
                    byte[] IV = new byte[lenIV];

                    // Extract the key and IV
                    // starting from index 8
                    // after the length values.
                    inFs.Seek(8, SeekOrigin.Begin);
                    inFs.Read(KeyEncrypted, 0, lenK);
                    inFs.Seek(8 + lenK, SeekOrigin.Begin);
                    inFs.Read(IV, 0, lenIV);
                    Directory.CreateDirectory(DecriptionFolder);
                    // Use RSACryptoServiceProvider
                    // to decrypt the AesManaged key.
                    byte[] KeyDecrypted = rsaPrivateKey.Decrypt(KeyEncrypted, false);

                    // Decrypt the key.
                    using (ICryptoTransform transform = aesManaged.CreateDecryptor(KeyDecrypted, IV))
                    {

                        // Decrypt the cipher text from
                        // from the FileSteam of the encrypted
                        // file (inFs) into the FileStream
                        // for the decrypted file (outFs).
                        using (FileStream outFs = new FileStream(outFile, FileMode.Create))
                        {

                            int count = 0;
                            int offset = 0;

                            int blockSizeBytes = aesManaged.BlockSize / 8;
                            byte[] data = new byte[blockSizeBytes];

                            // By decrypting a chunk a time,
                            // you can save memory and
                            // accommodate large files.

                            // Start at the beginning
                            // of the cipher text.
                            inFs.Seek(startC, SeekOrigin.Begin);
                            using (CryptoStream outStreamDecrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                            {
                                do
                                {
                                    count = inFs.Read(data, offset, blockSizeBytes);
                                    offset += count;
                                    outStreamDecrypted.Write(data, 0, count);
                                }
                                while (count > 0);

                                outStreamDecrypted.FlushFinalBlock();
                                outStreamDecrypted.Close();
                            }
                            outFs.Close();
                        }
                        inFs.Close();
                    }

                }
            }
        }

    }
}
