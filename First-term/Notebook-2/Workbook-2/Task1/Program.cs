using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\r\tРеализуйте программный продукт средствами языка C# со\r\nследующим функционалом:\r\n\tВычисление значения функции f(x) (соответствующей вашему\r\nварианту) с помощью ряда Маклорена с заданной точностью е (e и x\r\nвводятся с клавиатуры, е <0.01);\r\n\tВычисление n-го члена ряда (n и x вводятся с клавиатуры).");
            Console.WriteLine("Программа вычисления e^x с помощью ряда Маклорена");

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Вычислить e^x с заданной точностью ε");
                Console.WriteLine("2. Вычислить n-й член ряда");
                Console.WriteLine("3. Выйти");
                Console.Write("Ваш выбор: ");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CalculateWithPrecision();
                        break;
                    case "2":
                        CalculateNthTerm();
                        break;
                    case "3":
                        Console.WriteLine("Выход из программы.");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        static void CalculateWithPrecision()
        {
            double x = ReadDouble("Введите x: ");
            double eps = ReadDouble("Введите точность ε (0 < ε < 0,01): ");

            if (eps <= 0 || eps >= 0.01)
            {
                Console.WriteLine("Ошибка: ε должно быть в диапазоне (0, 0,01)");
                return;
            }

            double sum = 1.0; 
            double element = 1.0; 
            int n = 0;

            Console.WriteLine($"\nРяд для e^{x}:");
            Console.WriteLine($"[{n}]: 1 = {element:F15}");

            while (Math.Abs(element) >= eps)
            {
                n++;
                element *= x / n;
                sum += element;
                Console.WriteLine($"[{n}]: x^{n} / {n}! = {element:F15}");
            }

            Console.WriteLine($"\ne^{x} ≈ {sum:F8}");
            Console.WriteLine($"Использовано членов: {n + 1}");
        }

        static void CalculateNthTerm()
        {
            double x = ReadDouble("Введите x: ");
            int n = ReadInt("Введите номер члена n (n ≥ 0): ", min: 0);

            double term = 1.0;
            for (int i = 1; i <= n; i++)
                term *= x / i;

            if (n == 0)
                Console.WriteLine("0-й член: 1");
            else
                Console.WriteLine($"{n}-й член: x^{n} / {n}! = {term:F15}");
        }

        static double ReadDouble(string input)
        {
            while (true)
            {
                Console.Write(input);
                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;
                Console.WriteLine("Ошибка: введите корректное число.");
            }
        }

        static int ReadInt(string input, int min = int.MinValue)
        {
            while (true)
            {
                Console.Write(input);
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min)
                    return value;
                Console.WriteLine($"Ошибка: введите целое число ≥ {min}.");
            }
        }
    }
}