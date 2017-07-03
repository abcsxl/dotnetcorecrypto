using System;
using System.Security.Cryptography;
using dotnetcorecrypto;

namespace dotnetcoredes
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] key = "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF".HexToByteArray();
            byte[] data = "1122334455667788".HexToByteArray();
            byte[] iv = "0000000000000000".HexToByteArray();


            TripleDES tripleDES = TripleDES.Create();
            tripleDES.Mode =  CipherMode.ECB;
            tripleDES.Padding = PaddingMode.Zeros;

            byte[] allKey = new byte[24];
            Buffer.BlockCopy(key, 0, allKey, 0, 16);
            Buffer.BlockCopy(key, 0, allKey, 16, 8);

            ICryptoTransform trans = tripleDES.CreateEncryptor(allKey, iv);

            byte[] res = trans.TransformFinalBlock(data, 0, data.Length);

            Console.WriteLine(res.ByteArrayToHex());

            Console.ReadKey(true);
        }
    }
}