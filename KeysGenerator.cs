namespace RSA_Algorithm
{
    public class KeysGenerator
    {
        private int _p;
        private int _q;
        private int _n;
        private int _phi;
        private int _e;
        private int _d;
        private Random _random;

        public KeysGenerator()
        {
            _random = new Random();
        }

        public void CalculateKeys()
        {
            CalculateE();
            CalculateD();
            Console.WriteLine($"p = {_p}");
            Console.WriteLine($"q = {_q}");
            Console.WriteLine($"n = p * q = {_n}");
            Console.WriteLine($"phi(n) = (p - 1) * (q - 1) = {_phi}\n");
            Console.WriteLine($"Compute e:\n\t1 < e < phi(n)\n\te and phi(n) must be coprime");
            Console.WriteLine($"e = {_e}\n");
            Console.WriteLine("Compute d:\n\t (d * e) % phi(n) = 1");
            Console.WriteLine($"d = {_d}\n");
            Console.WriteLine($"Encryption key: (e, n) => ({_e}, {_n})");
            Console.WriteLine($"Decryption key: (d, n) => ({_d}, {_n})");
        }

        public int GetKeyForEncryption()
        {
            return _e;
        }

        public int GetKeyForDecryption()
        {
            return _d;
        }

        public int GetN()
        {
            return _n;
        }

        private void ChooseRandomPAndQPrimeNumbers()
        {
            int randomIndexP = _random.Next(0, PrimeNumbersFiller.PrimeNumbers.Count - 1);
            int randomIndexQ = _random.Next(randomIndexP + 1, PrimeNumbersFiller.PrimeNumbers.Count);

            _p = PrimeNumbersFiller.PrimeNumbers[randomIndexP];
            _q = PrimeNumbersFiller.PrimeNumbers[randomIndexQ];
        }

        private void CalculateN()
        {
            ChooseRandomPAndQPrimeNumbers();

            _n = _p * _q;
        }

        private void CalculatePhi()
        {
            CalculateN();

            _phi = (_p - 1) * (_q - 1);
        }

        private void CalculateE()
        {
            CalculatePhi();

            for (int i = 0; i < PrimeNumbersFiller.PrimeNumbers.Count; i++)
            {
                if (GreatestCommonDivisor(PrimeNumbersFiller.PrimeNumbers[i], _phi) == 1 &&
                    PrimeNumbersFiller.PrimeNumbers[i] < _phi)
                {
                    _e = PrimeNumbersFiller.PrimeNumbers[i];
                    break;
                }
            }
        }

        private void CalculateD()
        {
            for (int i = _e; i < 100000000; i++)
            {
                if ((i * _e) % _phi == 1)
                {
                    _d = i;
                    break;
                }
            }
        }

        private int GreatestCommonDivisor(int a, int b)
        {
            if (a % b == 0)
            {
                return b;
            }
            else
            {
                return GreatestCommonDivisor(b, a % b);
            }
        }
    }
}