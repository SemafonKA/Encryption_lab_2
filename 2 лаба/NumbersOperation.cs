namespace RSA_cryptoprogram
{
    public static class NumbersOperation
    {
        public class ExtGcdElem
        {
            public ulong gcd;
            public long coefA;
            public long coefB;

            public ExtGcdElem(ulong gcd, long coefA, long coefB)
            {
                this.gcd = gcd;
                this.coefA = coefA;
                this.coefB = coefB;
            }
        }

        /// <summary>
        /// Greatest Common Divisor (наибольший общий делитель)
        /// Based on Euclidean algorithm
        /// </summary>
        public static ulong GCD(ulong num1, ulong num2)
        {
            var lower = num1 > num2 ? num2 : num1;
            var upper = num1 < num2 ? num2 : num1;

            var remainder = upper % lower;        // остаток деления чисел

            while (remainder > 0)
            {
                upper = lower;
                lower = remainder;
                remainder = upper % lower;
            }

            return lower;
        }

        /// <summary>
        /// Extended Euclidean algorithm GCD
        /// Return result of solwe coefA*num1 + coefB*num2 = gcd
        /// </summary>
        public static ExtGcdElem ExtGcd(ulong num1, ulong num2)
        {
            var r1 = num1;
            var r2 = num2;
            var s1 = 1L; 
            var s2 = 0L;
            var t1 = 0L;
            var t2 = 1L;
            
            while (r1 % r2 != 0)
            {
                long divRes = (long)(r1 / r2);
                (r1, r2) = (r2, r1 % r2);
                (s1, s2) = (s2, s1 - s2 * divRes);
                (t1, t2) = (t2, t1 - t2 * divRes);
            }

            return new ExtGcdElem(r2, s2, t2);
        }

            /// <summary>
            /// Least Common Multiple (наименьшее общее кратное)
            /// </summary>
            public static ulong LCM(uint num1, uint num2)
        {
            return ((ulong)num1 * num2) / GCD(num1, num2);
        }
        
        /// <summary>
        /// Check if num is prime
        /// </summary>
        public static bool IsPrime(uint num)
        {
            // All prime numbers is 2, or 3, or 6*i +- 1
            if (num == 2 || num == 3) return true;

            if (num % 2 == 0 || num % 3 == 0) return false;

            // Check all prime numbers before sqrt(num) 
            for (uint i = 6; i <= Math.Sqrt(num); i+=6)
            {
                if (num % (i - 1) == 0) return false;
                if (num % (i + 1) == 0) return false;
            }

            return true;
        }
    }
}
