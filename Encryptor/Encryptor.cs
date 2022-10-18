
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
            ulong result = 1;
            ulong moduledMessage = message % N;

            for (ulong i = 0; i < E; i++)
            {
                result = (result * moduledMessage) % N;
            }

            return result;
        }
    }
}
