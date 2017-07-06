using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.Text;
using dotnetcorecrypto;

namespace bouncycastlersa
{
    class RSA
    {
        IAsymmetricBlockCipher engine = new RsaEngine();
        public void GenerateKey()
        {
            RsaKeyPairGenerator g = new RsaKeyPairGenerator();
            KeyGenerationParameters k = new KeyGenerationParameters(new SecureRandom(), 1024);
            g.Init(k);
            
            var pair = g.GenerateKeyPair();

            RsaPrivateCrtKeyParameters pri = (RsaPrivateCrtKeyParameters)pair.Private;

            //parms.D = "4DB40EBC270702CB13A8CB1CF0F75E40B8335697E87CCB1A8CB92B77A2002699B39736BE6DFEBDA6C9059E3532168A6EB6DB7DA337C63D2F469DA83EA7309ABC9A8E66808C591D744C93A6FE1F5CB7EB39932DB86C701029DFF424469A12BA4973FA8C416BB860BFC17FA9A55978102AF5669239F918ABC6DCA5FC11D82B9D01".HexToByteArray();
            //parms.DP = "BDC4FEA9C1957052BBB43DE56B5099D0E09B889AFEC2F1EE4546037A4C83ADE97A9A9BC2062024BC51229836E9224B2A19612BCC71E739C10FD0A3B7365C2261".HexToByteArray();
            //parms.DQ = "BF8E8C7B38A0E04EF21BB4CAC67EEFC1082A53A0231C727383609404247CA11F182FC3111A8ABE0524FB9CC8DB3D1E5126B6613BB4D01043CCB2768AE49E7A89".HexToByteArray();
            //parms.P = "E42BCFF4F4640C27DD80C681BC84C9F1A1588393041E6192E4A983CB441B1ED45B43FEB9B93B53CDEC7C2AB57E7B49CF42C2664F5595DD1624850B59E14A4F21".HexToByteArray();
            //parms.Q = "C0D7BB75086E750F3048E30926DFEB9D3FBBE7D14729C8B9D24E44B1B72CBDCEFDD72DBABFAA4690105C9F842515218B6672021DB09C8FB8A36C98308DDAF817".HexToByteArray();
            //parms.InverseQ = "8D5BB212BDFC259B8F73F569584DE3A59D8BF872BBA249F530B078604D3E12E18DF072E35AA268484DAB3FA9A08975534E6535827422F060B03E835600B116AA".HexToByteArray();
            //parms.Modulus = "ABE123D7AE76144574BFBD2340FAA2DB3F516202D37D867984A56A3735420D9073FF65E716564C4A92B8003B4F8F28EEA062E2C8B6918C674DC5B8029F2F8A0E9DD0FD5B032956FE1D07748A37A5320CB28BAFC0746A2DE92D6DD0645BF63AD221410E3689808C4D35C3E83BCF05498B4D98267C8961D9FC18694C5FC96F13F7".HexToByteArray();
            //parms.Exponent = "00010001".HexToByteArray();

            Console.WriteLine(pri.Exponent.ToByteArrayUnsigned().ByteArrayToHex());
            Console.WriteLine(pri.DP.ToByteArrayUnsigned().ByteArrayToHex());
            Console.WriteLine(pri.DQ.ToByteArrayUnsigned().ByteArrayToHex());
            Console.WriteLine(pri.P.ToByteArrayUnsigned().ByteArrayToHex());
            Console.WriteLine(pri.Q.ToByteArrayUnsigned().ByteArrayToHex());
            Console.WriteLine(pri.QInv.ToByteArrayUnsigned().ByteArrayToHex());
            Console.WriteLine(pri.Modulus.ToByteArrayUnsigned().ByteArrayToHex());
            Console.WriteLine(pri.PublicExponent.ToByteArrayUnsigned().ByteArrayToHex());

            Org.BouncyCastle.Math.BigInteger

        }

        public byte[] Encrypt(byte[] mod, byte[] pubExp, byte[] data)
        {
            RsaKeyParameters pubParameters = new RsaKeyParameters(false, BitConverter., pubExp);

            engine.Init(true, pubParameters);
            byte[] rv = new byte[cipher.GetOutputSize(data.Length)];
            int tam = cipher.ProcessBytes(data, 0, data.Length, rv, 0);
            cipher.DoFinal(rv, tam);

            //BufferedBlockCipher bufferedCipher = new BufferedBlockCipher(desedeEngine);

            // Create the KeyParameter for the DES3 key generated.   KeyParameter keyparam = ParameterUtilities.CreateKeyParameter("DESEDE", keyDES3);  byte[] output = new byte[bufferedCipher.GetOutputSize(message.Length)];  bufferedCipher.Init(true, keyparam);  output = bufferedCipher.DoFinal(message); 

            return rv;
        }
    }
}
