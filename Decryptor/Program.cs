using RSA_cryptoprogram;

Console.WriteLine("Введите закрытый ключ: ");

try
{
    Console.Write("N: ");
    var inp = Console.ReadLine();
    var n = ulong.Parse(inp);
    Console.Write("D: ");
    inp = Console.ReadLine();
    var d = ulong.Parse(inp);

    Console.Write("Напишите сообщщение для дешифровки (число): ");
    inp = Console.ReadLine();
    var message = ulong.Parse(inp);

    var encryptor = new Decryptor(n, d);
    var encrMessage = encryptor.DecryptMessage(message);

    Console.WriteLine($"Полученное расшифрованное сообщение: {encrMessage}");
}
catch (Exception e)
{
    Console.WriteLine("Неправильно введены данные.");
    return;
}