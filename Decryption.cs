using System.Numerics;

namespace RSA_Algorithm
{
    public class Decryption
    {
        public static int d;
        public static int n;

        public static int Decrypt(int number)
        {
            return (int)BigInteger.ModPow(number, d, n);
        }
    }
}