namespace RSA_cryptoprogram
{
    public class RSA_Keygen
    {
        public uint P { get; private set; }
        public uint Q { get; private set; }
        public uint N { get => P * Q; }
        public ulong Lambda { get; private set; }
        public ulong E { get; private set; }
        public ulong D { get; private set; }

        private ulong GetE()
        {
            // E must be in range (1; Lambda)
            // and also GCD(E, Lambda) == 1
            // then we choose E as a prime number number or as a random number from { 6*k +- 1 }
            // and then check GCD(E, Lambda) == 1

            if (Lambda == 3) return 2;
            if (Lambda <= 5) return 3;

            var rand = new Random();
            var upperIdx = Lambda / 6;
            ulong e;
            do
            {
                var idx = (ulong)rand.NextInt64(1, (long)upperIdx + 1);
                e = 6 * idx - 1;
                if (NumbersOperation.GCD(e, Lambda) != 1)
                {
                    e += 2;
                }
            } while (NumbersOperation.GCD(e, Lambda) != 1);

            return e;
        }
        private ulong GetD()
        {
            var extGcd = NumbersOperation.ExtGcd(E, Lambda);
            if (extGcd.coefA < 0)
            {
                var mult = extGcd.coefA * (long)E + (long)Lambda;
                while (mult < 0 || mult % (long)E != 0)
                {
                    mult += (long)Lambda;
                }
                extGcd.coefA = mult / (long)E;
            }
            return (ulong)extGcd.coefA;
        }

        public RSA_Keygen (uint p, uint q)
        {
            if (!NumbersOperation.IsPrime(p) || !NumbersOperation.IsPrime(q))
            {
                throw new Exception("Err: p or q is not a prime numbers.");
            }

            P = p;
            Q = q;

            Lambda = NumbersOperation.LCM(P - 1, Q - 1);
            E = GetE();
            D = GetD();
        }
    }
}
