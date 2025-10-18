using System;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Требуется написать программу, которая по заданным количеству n\r\nи размеру модулей a и b, а также размеру поля h и w для их размещения,\r\nопределяет максимальную толщину слоя дополнительной защиты d,\r\nкоторый можно добавить к каждому модулю. (Все данные вводятся с\r\nклавиатуры)");
            Console.Write("Введите n: ");
            int n = ReadInt();
            Console.Write("Введите a: ");
            int a = ReadInt();
            Console.Write("Введите b: ");
            int b = ReadInt();
            Console.Write("Введите w: ");
            int w = ReadInt();
            Console.Write("Введите h: ");
            int h = ReadInt();

            int maxD = Math.Min(w, h) / 2;
            int result = -1;
            for (int d = 0; d <= maxD; d++)
            {
                int moduleW1 = a + 2 * d; 
                int moduleH1 = b + 2 * d;
                int moduleW2 = b + 2 * d;
                int moduleH2 = a + 2 * d;
                if (CanPlaceModulesMixed(n, moduleW1, moduleH1, moduleW2, moduleH2, w, h))
                {
                    result = d;
                }
                else
                {
                    break;
                }
            }

            if (result == -1)
            {
                Console.WriteLine("Ответ: невозможно разместить модули даже без дополнительной защиты.");
            }
            else
            {
                Console.WriteLine($"Ответ: максимальная толщина защиты d = {result}");
            }
        }
        static bool CanPlaceModulesMixed(int n, int w1, int h1, int w2, int h2, int W, int H)
        {
            if (GridFit(n, w1, h1, W, H) || GridFit(n, w2, h2, W, H))
            {
                return true;
            }

            for (int k = 1; k < n; k++)
            {
                int countType2 = n - k;
                for (int splitW = 1; splitW < W; splitW++)
                {
                    if (GridFit(k, w1, h1, splitW, H) && GridFit(countType2, w2, h2, W - splitW, H))
                    {
                        return true;
                    }
                }
                for (int splitW = 1; splitW < W; splitW++)
                {
                    if (GridFit(k, w2, h2, splitW, H) && GridFit(countType2, w1, h1, W - splitW, H))
                    {
                        return true;
                    }
                }
                for (int splitH = 1; splitH < H; splitH++)
                {
                    if (GridFit(k, w1, h1, W, splitH) && GridFit(countType2, w2, h2, W, H - splitH))
                    {
                        return true;
                    }
                }
                for (int splitH = 1; splitH < H; splitH++)
                {
                    if (GridFit(k, w2, h2, W, splitH) && GridFit(countType2, w1, h1, W, H - splitH))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static bool GridFit(int n, int wMod, int hMod, int W, int H)
        {
            if (wMod > W || hMod > H) return false;
            int count = (W / wMod) * (H / hMod);
            return count >= n;
        }
        static int ReadInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;
                Console.Write("Некорректный ввод. Пожалуйста, введите целое число: ");
            }
        }
    }
}
