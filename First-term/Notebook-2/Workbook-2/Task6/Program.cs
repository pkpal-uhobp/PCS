using System;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tВ чашку Петри кладут N бактерий и добавляют X капель\r\nантибиотика (N и X вводятся с клавиатуры).\r\n\tИзвестно, что число бактерий в чашке Петри увеличивается в два\r\nраза каждый час, а каждая капля антибиотика в первый час убивает 10\r\nбактерий, во второй час — 9 бактерий, в следующий — 8 и так далее,\r\nпока антибиотик не перестанет действовать. Заметьте, что сначала число\r\nбактерий увеличивается, а затем только действует антибиотик.\r\n\tПользователь вашей программы вводит N и X, а программа\r\nпечатает на экране, сколько бактерий останется в чашке Петри в конце\r\nкаждого часа, до тех пор, пока не закончатся бактерии или антибиотик\r\nне перестанет действовать.\r\n\tЦикл не должен быть бесконечным (после того как количество\r\nантибиотики или бактерий становиться равным нулю выполнение\r\nпрограммы должно быть завершено).");
            Console.Write("\nВведите количество бактерий: ");
            int bacteria = ReadInt();
            Console.Write("Введите количество антибиотика: ");
            int antibioticDrops = ReadInt();
            int hour = 1;
            int killsPerHour = 10;
            while (bacteria > 0 && killsPerHour > 0 && antibioticDrops > 0)
            {
                bacteria *= 2;
                int killed = Math.Min(bacteria, killsPerHour * antibioticDrops);
                bacteria -= killed;
                Console.WriteLine($"После {hour} часа бактерий осталось {bacteria}");
                killsPerHour--;
                hour++;
                if (bacteria <= 0)
                {
                    break;
                }
            }
        }

        static int ReadInt()
        {
            int value;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                Console.Write("Некорректный ввод. Введите число: ");
            }
        }
    }
}