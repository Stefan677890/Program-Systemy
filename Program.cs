while (true)
{ 
    Console.WriteLine("Wybierz z jakiego systemu na jaki chcesz przekonwertować");
    Console.WriteLine("1. z binarnego na dziesięny");
    Console.WriteLine("2. z dziesiętnego na binarny");
    Console.WriteLine("3. z dziesiętnego na szesnastkowy");
    Console.WriteLine("4. z szesnastkowego na dziesiętny");
    Console.WriteLine("5. z dziesiętnego na ósemkowy");
    Console.WriteLine("6. z ósemkowego na dziesiętny");
    Console.WriteLine("7. Wyłącz program");

    int wybor = int.Parse(Console.ReadLine()!);

    switch (wybor)
    {
        case 1:
            Console.WriteLine("Podaj liczbę w systemie binarnym");
            string bin = Console.ReadLine()!;
            if (IsBin(bin))
                break;
            Console.WriteLine(BinToDec(bin));
            break;

        case 2:
            Console.WriteLine("Podaj liczbę w systemie dziesiętnym");
            Console.WriteLine(DecToBin(Convert.ToInt32(Console.ReadLine()!)));
            break;

        case 3:
            Console.WriteLine("Podaj liczbę w systemie dziesiętnym");
            Console.WriteLine(DecToHex(Convert.ToInt32(Console.ReadLine()!)));
            break;

        case 4:
            Console.WriteLine("Podaj liczbę w systemie szesnastkowym");
            string hex = Console.ReadLine()!;
            if (IsHex(hex)) 
               break;
            Console.WriteLine(HexToDec(hex));
            break;

        case 5:
            Console.WriteLine("Podaj liczbę w systemie dziesiętnym");
            Console.WriteLine(DecToOct(Convert.ToInt32(Console.ReadLine()!)));
            break;

        case 6:
            Console.WriteLine("Podaj liczbę w systemie ósemkowym");
            string oct = Console.ReadLine()!;
            if (IsOct(oct)) break;
            Console.WriteLine(OctToDec(oct));
            break;

        case 7:
            Console.WriteLine("Wyłączamy program!");
            break;

        default:
            Console.WriteLine("Wybierz jedną z podanych opcji!!!");
            break;
    }

    static int BinToDec(string bin_value)
    {
        int dec = 0;

        for (int i = 0; i < bin_value.Length; i++)
        {
            if (bin_value[i] == '0')
            {
                dec += (int)Math.Pow(2, bin_value.Length - 1 - i) * 0;
            }
            if (bin_value[i] == '1')
            {
                dec += (int)Math.Pow(2, bin_value.Length - 1 - i) * 1;
            }
            if (bin_value[i] != '1' && bin_value[i] != '0')
            {
                return 0;
            }
        }
        return dec;
    }

    static string DecToBin(int dec_value)
    {
        string bin_value = "";
        while (dec_value > 0)
        {
            bin_value += dec_value % 2;
            dec_value /= 2;
        }
        string bin_output = "";
        for (int i = bin_value.Length - 1; i > -1; i--)
        {
            bin_output += bin_value[i];
        }
        return bin_output;
    }

    static string DecToHex(int dec_value)
    {
        string hexChars = "0123456789ABCDEF";
        string hex = "";

        if (dec_value == 0)
            return "0";

        while (dec_value > 0)
        {
            int remainder = dec_value % 16;
            hex = hexChars[remainder] + hex;
            dec_value /= 16;
        }

        return hex;
    }

    static int HexToDec(string hex_value)
    {
        string hexChars = "0123456789ABCDEF";
        hex_value = hex_value.ToUpper();
        int dec = 0;

        for (int i = 0; i < hex_value.Length; i++)
        {
            int digit = hexChars.IndexOf(hex_value[i]);

            if (digit == -1)
                return 0;

            dec += digit * (int)Math.Pow(16, hex_value.Length - 1 - i);
        }

        return dec;
    }

    static string DecToOct(int dec_value)
    {
        if (dec_value == 0)
            return "0";

        string oct_value = "";

        while (dec_value > 0)
        {
            oct_value = (dec_value % 8) + oct_value;
            dec_value /= 8;
        }

        return oct_value;
    }

    static int OctToDec(string oct_value)
    {
        int dec = 0;

        for (int i = 0; i < oct_value.Length; i++)
        {
            int digit = oct_value[i] - '0';

            if (digit < 0 || digit > 7)
                return 0;

            dec += digit * (int)Math.Pow(8, oct_value.Length - 1 - i);
        }

        return dec;
    }

    static bool IsBin(string s)
    {
        foreach (char c in s)
            if (c != '0' && c != '1')
            {
                Console.WriteLine("Napisane liczby są w złym systemie!");
                return false;
            }
        return true;
    }

    static bool IsHex(string s)
    {
        string hexChars = "0123456789ABCDEF";
        foreach (char c in s)
            if (!hexChars.Contains(c))
            {
                Console.WriteLine("Napisane liczby są w złym systemie!!");
                return false;
            }
        return true;
    } 

    static bool IsOct(string s)
    {
        foreach (char c in s)
            if (c < '0' || c > '7')
            {
                Console.WriteLine("Napisane liczby są w złym systemie!!");
                return false;
            }
        return true;
    }
}