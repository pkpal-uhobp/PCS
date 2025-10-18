using System;

namespace Task5
{
    class Program
    {
        const int WATER_FOR_AMERICANO = 300;
        const int PRICE_AMERICANO = 150;
        const int WATER_FOR_LATTE = 30;
        const int MILK_FOR_LATTE = 270;
        const int PRICE_LATTE = 170;

        static void Main()
        {
            Console.WriteLine("\tКофейный аппарат может готовить два напитка: американо и латте.\r\nДля американо требуется 300 мл воды (цена 150 рублей), а для латте 30\r\nмл воды и 270 мл молока (цена 170 рублей).\r\n\tНапишите программу, которая спрашивает у пользователя (это\r\nдействие программа делает один раз в начале работы), сколько всего\r\n9\r\nмиллилитров молока и воды залито в кофейный аппарат.\r\n\tПосле чего начинает обслуживание пользователей, запрашивается,\r\nкакой напиток хочет заказать посетитель. Пользователь выбирает один\r\nиз двух напитков, программа отвечает одним из трёх вариантов: «Ваш\r\nнапиток готов», «Не хватает воды» или «Не хватает молока», после чего\r\nпереходит к обслуживанию следующего посетителя. Если молока и воды\r\nне хватает ни на один вид напитка, программа выдаёт отчёт и\r\nзавершается.\r\n\tВ отчёте должно быть написано, что ингредиенты подошли к\r\nконцу, должен быть указан остаток воды и молока в машине, должно\r\nбыть указано, сколько всего было приготовлено чашек американо и латте\r\nза эту смену и итоговый заработок аппарата. ");
            Console.Write("\n    Введите количество воды в мл: ");
            int totalWater = ReadInt();
            Console.Write("    Введите количество молока в мл: ");
            int totalMilk = ReadInt();

            int cupsAmericano = 0;
            int cupsLatte = 0;
            int totalIncome = 0;

            while (true)
            {
                bool canMakeAmericano = totalWater >= WATER_FOR_AMERICANO;
                bool canMakeLatte = totalWater >= WATER_FOR_LATTE && totalMilk >= MILK_FOR_LATTE;

                if (!canMakeAmericano && !canMakeLatte)
                {
                    Console.WriteLine("    Недостаточно ингредиентов для приготовления любого напитка.");
                    break;
                }
                Console.WriteLine("    Доступные напитки:");
                if (canMakeAmericano)
                {
                    Console.WriteLine("      1 — Американо");
                }
                if (canMakeLatte)
                {
                    Console.WriteLine("      2 — Латте");
                }

                Console.Write("    Ваш выбор: ");
                int choice = ReadInt();
                if (choice == 1 && canMakeAmericano)
                {
                    totalWater -= WATER_FOR_AMERICANO;
                    cupsAmericano++;
                    totalIncome += PRICE_AMERICANO;
                    Console.WriteLine("    Ваш напиток готов.");
                }
                else if (choice == 2 && canMakeLatte)
                {
                    totalWater -= WATER_FOR_LATTE;
                    totalMilk -= MILK_FOR_LATTE;
                    cupsLatte++;
                    totalIncome += PRICE_LATTE;
                    Console.WriteLine("    Ваш напиток готов.");
                }
                else
                {
                    Console.WriteLine("    Недоступный или неверный выбор. Пожалуйста, выберите из доступных напитков.");
                }

                Console.WriteLine();
            }
            Console.WriteLine("    *Отчёт*");
            Console.WriteLine("    Ингредиентов осталось:");
            Console.WriteLine($"       Вода: {totalWater} мл");
            Console.WriteLine($"       Молоко: {totalMilk} мл");
            Console.WriteLine($"    Кружек американо приготовлено: {cupsAmericano}");
            Console.WriteLine($"    Кружек латте приготовлено: {cupsLatte}");
            Console.WriteLine($"    Итого: {totalIncome} рублей.");
        }

        static int ReadInt()
        {
            int value;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out value))
                {
                    return value;
                }
                Console.Write("    Некорректный ввод. Введите число: ");
            }
        }
    }
}