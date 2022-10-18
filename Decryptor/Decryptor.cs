
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
            ulong result = 1;
            ulong moduledMessage = message % N;

            for (ulong i = 0; i < D; i++)
            {
                result = (result * moduledMessage) % N;
            }

            return result;
        }
    }
}
