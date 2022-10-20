using RSA_cryptoprogram;

int menuSwitcher = 4;

while (menuSwitcher != 0)
{
    Console.WriteLine("Выберите нужную программу: ");
    Console.WriteLine("  0) Выход из программы");
    Console.WriteLine("  1) Генератор ключа");
    Console.WriteLine("  2) Зашифровщик сообщений");
    Console.WriteLine("  3) Расшифровщик сообщений");
    Console.Write("> ");

    var inp = Console.ReadLine();

    if (int.TryParse(inp, out menuSwitcher))
    {
        switch (menuSwitcher)
        {
            case 1:
                KeygenMain.Main();
                break;
            case 2:
                EncryptorMain.Main();
                break;
            case 3:
                DecryptorMain.Main();
                break;
        }
    }
}

