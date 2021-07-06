using System;
using System.Security.Cryptography;
using Api.Domain.Interfaces.Utils;

namespace Api.Service.Utils
{
    public class Hash : IHash
    {
        string IHash.Cryptography(string input)
        {
            var hashedResult = "";

            var pwd = Environment.GetEnvironmentVariable("HASH");

            var utf8 = new System.Text.UTF8Encoding();

            var HashProvider = new MD5CryptoServiceProvider();

            var TDESKey = HashProvider.ComputeHash(utf8.GetBytes(pwd));

            var TDESAlgorithm = new TripleDESCryptoServiceProvider();

            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            var DataToEncrypt = utf8.GetBytes(input);
            try
            {
                var Encryptor = TDESAlgorithm.CreateEncryptor();
                var result = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
                hashedResult = Convert.ToBase64String(result);
            }
            catch (System.Exception)
            {
                hashedResult = null;
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return hashedResult;
        }
    }
}