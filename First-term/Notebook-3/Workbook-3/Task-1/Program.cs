using System;

class Program
{
    static void Main()
    {
        int n;
        while (true)
        {
            Console.Write("Введите целое число, не содержащее нулей: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out n))
            {
                Console.WriteLine("Ошибка: введено не целое число.");
                continue;
            }
            if (input.Contains('0'))
            {
                Console.WriteLine("Ошибка: число не должно содержать нулей.");
                continue;
            }
            if (n < 0)
            {
                Console.WriteLine("Ошибка: число должно быть положительным.");
                continue;
            }
            break;
        }
        int reversed = ReverseNumber(n);
        Console.WriteLine($"Результат: {reversed}");
    }
    static int ReverseNumber(int n)
    {
        if (n < 10)
            return n;
        int lastDigit = n % 10;
        int remaining = n / 10;
        int power = (int)Math.Log10(remaining) + 1;
        return lastDigit * (int)Math.Pow(10, power) + ReverseNumber(remaining);
    }
}
