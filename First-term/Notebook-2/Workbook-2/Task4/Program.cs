using System;

namespace Task4
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\tНапишите программу, которая угадывает число, задуманное\r\nпользователем. Число загадывается в диапазоне от 0 до 63. Программа\r\nзадаёт вопросы вида «Ваше число больше такого-то?» и на основе\r\nответов пользователя («да-1» или «нет-0») угадывает число.\r\n\tАлгоритм, должен давать ответ за семь вопросов. ");
            Console.WriteLine("Загадайте число от 0 до 63. Я попробую его угадать.");
            Console.WriteLine("Отвечайте:");
            Console.WriteLine("  1 — если 'да' (ваше число больше X)");
            Console.WriteLine("  0 — если 'нет' (ваше число меньше или равно X)");
            Console.WriteLine("  2 — если 'да, это моё число'");
            Console.WriteLine();
            int left = 0;
            int right = 63;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                Console.Write($"Ваше число больше {mid}? ");
                int answer = ReadAnswer();

                if (answer == 2)
                {
                    Console.WriteLine($"Ваше число: {mid}");
                    return;
                }
                else if (answer == 1)
                {
                    left = mid + 1;
                }
                else if (answer == 0)
                {
                    right = mid - 1;
                }
            }
            Console.WriteLine("Вы, кажется, врёте. Нет числа, которое соответствует вашим ответам.");
        }
        static int ReadAnswer()
        {
            int answer;
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out answer) && (answer == 0 || answer == 1 || answer == 2))
                {
                    return answer;
                }
                Console.Write("Неверный ввод. Введите 0 (нет), 1 (да), или 2 (это моё число): ");
            }
        }
    }
}