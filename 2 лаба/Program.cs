using RSA_cryptoprogram;

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
}
catch (Exception e)
{
    Console.WriteLine("Некорректно введённые числа. Повторите попытку.");
    return;
}

var fullKey = new RSA_Keygen(p, q);
Console.WriteLine($"Полученный открытый ключ: ({fullKey.N}, {fullKey.E})");
Console.WriteLine($"Полученный закрытый ключ: ({fullKey.N}, {fullKey.D})");