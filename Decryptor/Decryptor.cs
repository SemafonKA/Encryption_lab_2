
namespace RSA_cryptoprogram
{
    public class Decryptor
    {
        public ulong N { get; private set; }
        public ulong D { get; private set; }

        public Decryptor (ulong n, ulong d)
        {
            N = n;
            D = d;
        }

        public ulong DecryptMessage (ulong message)
        {
            ulong moduledMessage = message % N;
            ulong result = 1;
            ulong z = moduledMessage;
            ulong power = D;

            while (power != 0)
            {
                if ((power & 1ul) == 1)
                {
                    result = (result * z) % N;
                }
                z = (z * z) % N;

                power >>= 1;
            }

            return result;
        }
    }
}
