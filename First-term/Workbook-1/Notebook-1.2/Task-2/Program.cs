using System;

namespace ATM
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите сумму для выдачи (кратную 100): ");
            if (!int.TryParse(Console.ReadLine(), out int amount))
            {
                Console.WriteLine("Ошибка: введите корректное число.");
                return;
            }
            if (amount < 0) {
                Console.WriteLine("Ошибка: сумма быть не отрицательной.");
                return;
            }
            if (amount > 150000)
            {
                Console.WriteLine("Ошибка: сумма не должна превышать 150 000 рублей.");
                return;
            }
            if (amount % 100 != 0)
            {
                Console.WriteLine("Ошибка: сумма должна быть кратна 100 рублям.");
                return;
            }
            int[] denominations = { 5000, 2000, 1000, 500, 200, 100 };
            int[] counts = new int[denominations.Length];
            int totalNotes = 0;

            int remaining = amount;
            for (int i = 0; i < denominations.Length; i++)
            {
                counts[i] = remaining / denominations[i];
                remaining %= denominations[i];
                totalNotes += counts[i];
            }
            if (remaining != 0)
            {
                Console.WriteLine("Ошибка: невозможно выдать точную сумму.");
                return;
            }
            Console.WriteLine("Выдача:");
            for (int i = 0; i < denominations.Length; i++)
            {
                if (counts[i] > 0)
                {
                    Console.WriteLine($"{counts[i]} купюра(ы) по {denominations[i]} руб.");
                }
            }

            Console.WriteLine($"Общее количество купюр: {totalNotes}");
        }
    }
}