using System;

namespace Task3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Пользователь вводит числа M и N. \r\nНапишите программу, которая\r\nпреобразует дробь M/N к несократимому виду и выдаёт получившийся\r\nрезультат. ");
            int numerator = ReadInteger("Введите числитель: ");
            int denominator = ReadInteger("Введите знаменатель: ");
            if (denominator == 0)
            {
                Console.WriteLine("Ошибка: знаменатель не может быть равен 0.");
                return;
            }
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
            else if (numerator == 0) {
                Console.WriteLine($"Результат: 0");
            }
            else {
                Console.WriteLine($"Результат: {numerator} / {denominator}");
            }
        }
        static int ReadInteger(string input)
        {
            int value;
            while (true)
            {
                Console.Write(input);
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                Console.WriteLine("Ошибка: введите целое число.");
            }
        }
        static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}