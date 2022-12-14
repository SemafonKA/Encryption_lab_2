using RSA_cryptoprogram;

namespace RSA_cryptoprogram
{
    public static class EncryptorMain
    {
        public static void Main()
        {
            Console.WriteLine("Введите открытый ключ: ");

            try
            {
                Console.Write("N: ");
                var inp = Console.ReadLine();
                var n = ulong.Parse(inp);
                Console.Write("E: ");
                inp = Console.ReadLine();
                var e = ulong.Parse(inp);

                Console.Write("Напишите сообщение для зашифровки (число): ");
                inp = Console.ReadLine();
                var message = ulong.Parse(inp);

                var encryptor = new Encryptor(n, e);
                var encrMessage = encryptor.EncryptMessage(message);

                Console.WriteLine($"Полученное зашифрованное сообщение: {encrMessage}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Неправильно введены данные.");
                return;
            }
        }
    }
}
