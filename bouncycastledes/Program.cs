using dotnetcorecrypto;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using System;

namespace bouncycastledes
{
    class Program
    {
        static void Main(string[] args)
        {
            IBlockCipher engine = new DesEngine();

            byte[] key = "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF".HexToByteArray();
            byte[] data = "1122334455667788".HexToByteArray();
            byte[] iv = "0000000000000000".HexToByteArray();

            BufferedBlockCipher cipher = new PaddedBufferedBlockCipher(new CbcBlockCipher(engine), new Pkcs7Padding());
            cipher.Init(true, new ParametersWithIV(new DesParameters(key), iv));
            byte[] rv = new byte[cipher.GetOutputSize(data.Length)];
            int tam = cipher.ProcessBytes(data, 0, data.Length, rv, 0);
            cipher.DoFinal(rv, tam);

            Console.WriteLine(rv.ByteArrayToHex());

            Console.ReadKey(true);
        }
    }
}