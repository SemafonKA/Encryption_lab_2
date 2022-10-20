using RSA_cryptoprogram;

namespace RSA_cryptoprogram
{
    public static class KeygenMain
    {
        public static void Main()
        {
            uint p, q;
            Console.WriteLine("Введите коэффициенты p и q");
            try
            {
                Console.Write("p: ");
                var inp = Console.ReadLine();
                p = uint.Parse(inp);
                Console.Write("q: ");
                inp = Console.ReadLine();
                q = uint.Parse(inp);
                var fullKey = new RSA_Keygen(p, q);

                Console.WriteLine($"Полученный открытый ключ: (N:{fullKey.N}, E:{fullKey.E})");
                Console.WriteLine($"Полученный закрытый ключ: (N:{fullKey.N}, D:{fullKey.D})");
            }
            catch (Exception e)
            {
                Console.WriteLine("Некорректно введённые числа. Повторите попытку.");
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}

