using System;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\tЕсли на билете сумма первых трёх цифр в номере билета равна\r\nсумме трёх последних, то этот билет считается счастливым. Напишите\r\nпрограмму, которая получала бы на вход шестизначный номер билета и\r\nвыводила, счастливый это билет или нет. К примеру: билеты 777 777 и\r\n255 642 — счастливые, а 123 456 — нет.\r\n\tИспользовать при решении задачи можно только простые базовые\r\nтипы (т.е. использование массивов, строк и коллекций запрещено,\r\nдолжно обрабатываться именно число).\r\n");
            long ticketNumber = ReadTicketNumber();
            int d1 = (int)(ticketNumber / 100000) % 10;
            int d2 = (int)(ticketNumber / 10000) % 10; 
            int d3 = (int)(ticketNumber / 1000) % 10; 
            int d4 = (int)(ticketNumber / 100) % 10;   
            int d5 = (int)(ticketNumber / 10) % 10;    
            int d6 = (int)(ticketNumber % 10);       
            int sumFirst = d1 + d2 + d3;
            int sumLast = d4 + d5 + d6;
            bool isLucky = sumFirst == sumLast;
            Console.WriteLine(isLucky);
        }
        static long ReadTicketNumber()
        {
            long number;
            while (true)
            {
                Console.Write("Введите номер билета: ");
                string? input = Console.ReadLine();
                if (long.TryParse(input, out number) && number >= 100000 && number <= 999999)
                {
                    return number;
                }
                Console.WriteLine("Ошибка: введите шестизначное число.");
            }
        }
    }
}