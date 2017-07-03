using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;

namespace bouncycastledes
{
    class TripleDES
    {
        //IBlockCipher engine = new DesEngine();
        IBlockCipher engine = new DesEdeEngine();

        public byte[] Encrypt(byte[] key, byte[] iv, byte[] data)
        {
            //BufferedBlockCipher cipher = new PaddedBufferedBlockCipher(engine, new ISO7816d4Padding());
            //BufferedBlockCipher cipher = new BufferedGenericBlockCipher(cipher.getUnderlyingCipher(), new ISO7816d4Padding());
            BufferedBlockCipher cipher = new BufferedBlockCipher(engine);
            //cipher.Init(true, new ParametersWithIV(new DesParameters(key), iv));
            cipher.Init(true, new DesEdeParameters(key));
            byte[] rv = new byte[cipher.GetOutputSize(data.Length)];
            int tam = cipher.ProcessBytes(data, 0, data.Length, rv, 0);
            cipher.DoFinal(rv, tam);

            //BufferedBlockCipher bufferedCipher = new BufferedBlockCipher(desedeEngine);

            // Create the KeyParameter for the DES3 key generated.   KeyParameter keyparam = ParameterUtilities.CreateKeyParameter("DESEDE", keyDES3);  byte[] output = new byte[bufferedCipher.GetOutputSize(message.Length)];  bufferedCipher.Init(true, keyparam);  output = bufferedCipher.DoFinal(message); 

            return rv;
        }

        public byte[] Decrypt(byte[] key, byte[] iv, byte[] data)
        {
            //BufferedBlockCipher cipher = new PaddedBufferedBlockCipher(engine, new ISO7816d4Padding());
            BufferedBlockCipher cipher = new BufferedBlockCipher(engine);
            //cipher.Init(false, new ParametersWithIV(new DesParameters(key), iv));
            cipher.Init(false, new DesEdeParameters(key));
            byte[] rv = new byte[cipher.GetOutputSize(data.Length)];
            int tam = cipher.ProcessBytes(data, 0, data.Length, rv, 0);
            cipher.DoFinal(rv, tam);

            return rv;
        }
    }
}
