using dotnetcorecrypto;
using System;

namespace bouncycastledes
{
    class Program
    {
        static void Main(string[] args)
        {

            byte[] key = "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF".HexToByteArray();
            byte[] data = "11223344556677881122334455667788".HexToByteArray();
            byte[] iv = "0000000000000000".HexToByteArray();

            TripleDES tripleDes = new TripleDES();

            byte[] res = tripleDes.Encrypt(key, iv, data);
            Console.WriteLine(res.ByteArrayToHex());

            res = tripleDes.Decrypt(key, iv, res);
            Console.WriteLine(res.ByteArrayToHex());

            Console.ReadKey(true);
        }
    }
}