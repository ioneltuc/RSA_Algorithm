using System.Numerics;

namespace RSA_Algorithm
{
    public class Encryption
    {
        public static int e;
        public static int n;

        public static int Encrypt(char character)
        {
            return (int)BigInteger.ModPow(character, e, n);
        }
    }
}