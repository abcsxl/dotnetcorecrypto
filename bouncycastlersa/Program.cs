using System;

namespace bouncycastlersa
{
    class Program
    {
        static void Main(string[] args)
        {
            RSA rsa = new RSA();
            rsa.GenerateKey();

            Console.ReadKey(true);
        }
    }
}