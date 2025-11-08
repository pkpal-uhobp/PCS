using System;

class Program
{
    private const int MAX_RECURSION_DEPTH = 10_000;

    static void Main(string[] args)
    {
        Console.WriteLine("Введите два целых неотрицательных числа m и n:");

        Console.Write("m = ");
        if (!long.TryParse(Console.ReadLine(), out long m) || m < 0)
        {
            Console.WriteLine("Ошибка: m должно быть неотрицательным целым числом.");
            return;
        }

        Console.Write("n = ");
        if (!long.TryParse(Console.ReadLine(), out long n) || n < 0)
        {
            Console.WriteLine("Ошибка: n должно быть неотрицательным целым числом.");
            return;
        }

        try
        {
            long result = AckermannSafe(m, n);
            Console.WriteLine($"Вывод: A({m},{n}) = {result}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Ошибка: переполнение числа (результат слишком велик для long).");
        }
    }

    public static long AckermannSafe(long m, long n, int depth = 0)
    {
        if (depth > MAX_RECURSION_DEPTH)
            throw new InvalidOperationException("Превышен лимит рекурсии. Функция Аккермана растёт слишком быстро для этих аргументов.");

        if (m == 0)
        {
            return checked(n + 1);
        }
        else if (n == 0)
        {
            return AckermannSafe(m - 1, 1, depth + 1);
        }
        else
        {
            long inner = AckermannSafe(m, n - 1, depth + 1);
            return AckermannSafe(m - 1, inner, depth + 1);
        }
    }
}