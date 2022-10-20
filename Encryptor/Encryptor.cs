
namespace RSA_cryptoprogram
{
    public class Encryptor
    {
        public ulong N { get; private set; }
        public ulong E { get; private set; }

        public Encryptor (ulong n, ulong e)
        {
            N = n;
            E = e;
        }

        public ulong EncryptMessage (ulong message)
        {
            ulong moduledMessage = message % N;
            ulong result = 1;
            ulong z = moduledMessage;
            ulong power = E;

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
