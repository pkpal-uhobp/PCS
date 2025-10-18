using System;

namespace CalendarMay
{
    class Program
    {
        static void Main()
        {
            int startDayOfWeek;
            int dayOfMonth;
            Console.Write("Введите номер дня недели, с которого начинается месяц (1-пн, ..., 7-вс): ");
            if (!int.TryParse(Console.ReadLine(), out startDayOfWeek) || startDayOfWeek < 1 || startDayOfWeek > 7)
            {
                Console.WriteLine("Ошибка: введите число от 1 до 7.");
                return;
            }
            Console.Write("Введите день месяца: ");
            if (!int.TryParse(Console.ReadLine(), out dayOfMonth) || dayOfMonth < 1 || dayOfMonth > 31)
            {
                Console.WriteLine("Ошибка: введите число от 1 до 31.");
                return;
            }
            bool isWeekend = IsWeekend(dayOfMonth, startDayOfWeek);
            bool isHoliday = IsSpecialHoliday(dayOfMonth);

            if (isWeekend || isHoliday)
            {
                Console.WriteLine("-----Проверяем выходной ли день-----");
                Console.WriteLine("Выходной день");
            }
            else
            {
                Console.WriteLine("-----Проверяем выходной ли день-----");
                Console.WriteLine("Рабочий день");
            }
        }
        static bool IsWeekend(int day, int startDayOfWeek)
        {
            int dayOfWeek = (startDayOfWeek + day - 1) % 7;
            return dayOfWeek == 6 || dayOfWeek == 0;
        }
        static bool IsSpecialHoliday(int day)
        {
            return (day >= 1 && day <= 5) || (day >= 8 && day <= 10);
        }
    }
}