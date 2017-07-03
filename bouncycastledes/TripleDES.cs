using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;

namespace bouncycastledes
{
    class TripleDES
    {
        IBlockCipher engine = new DesEngine();

        public byte[] Encrypt(byte[] key, byte[] iv, byte[] data)
        {
            BufferedBlockCipher cipher = new PaddedBufferedBlockCipher(new CbcBlockCipher(engine), new ISO7816d4Padding());
            cipher.Init(true, new ParametersWithIV(new DesParameters(key), iv));
            byte[] rv = new byte[cipher.GetOutputSize(data.Length)];
            int tam = cipher.ProcessBytes(data, 0, data.Length, rv, 0);
            cipher.DoFinal(rv, tam);

            return rv;
        }

        public byte[] Decrypt(byte[] key, byte[] iv, byte[] data)
        {
            BufferedBlockCipher cipher = new PaddedBufferedBlockCipher(new CbcBlockCipher(engine), new ISO7816d4Padding());
            cipher.Init(false, new ParametersWithIV(new DesParameters(key), iv));
            byte[] rv = new byte[cipher.GetOutputSize(data.Length)];
            int tam = cipher.ProcessBytes(data, 0, data.Length, rv, 0);
            cipher.DoFinal(rv, tam);

            return rv;
        }
    }
}
