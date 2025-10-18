double memory = 0;
double currentValue = 0;
double firstNumber = 0;
string pendingOperation = "";
bool waitingForSecondNumber = false;

double mathOperate(double num1, string operate, double num2 = 0)
{
    switch (operate)
    {
        case "+": return num1 + num2;
        case "-": return num1 - num2;
        case "*": return num1 * num2;
        case "/":
            if (num2 != 0) return num1 / num2;
            Console.WriteLine("Ошибка: деление на ноль.");
            return num1;
        case "%":
            if (num2 != 0) return num1 % num2;
            Console.WriteLine("Ошибка: деление на ноль.");
            return num1;
        case "^": return Math.Pow(num1, num2);
        case "x^2": return num1 * num1;
        case "sqrt":
            if (num1 < 0)
            {
                Console.WriteLine("Ошибка: квадратный корень из отрицательного числа.");
                return num1;
            }
            return Math.Sqrt(num1);
        case "1/x":
            if (num1 == 0)
            {
                Console.WriteLine("Ошибка: деление на ноль.");
                return num1;
            }
            return 1.0 / num1;
        default:
            Console.WriteLine("Неизвестная операция.");
            return num1;
    }
}

Console.WriteLine("Калькулятор запущен. Введите число или команду.");
Console.WriteLine("Операции: +, -, *, /, %, ^, x^2, sqrt, 1/x, M+, M-, MR, MC, C, Q\n");

while (true)
{
    Console.Write("> ");
    var input = Console.ReadLine()?.Trim();

    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Пустой ввод. Введите число или команду.");
        continue;
    }

    if (input.ToLower() == "Q")
    {
        Console.WriteLine("Калькулятор завершил работу.");
        break;
    }

    if (double.TryParse(input, out var number))
    {
        if (waitingForSecondNumber)
        {
            currentValue = number;
            waitingForSecondNumber = false;
            Console.WriteLine($"= {currentValue}");
        }
        else
        {
            currentValue = number;
            Console.WriteLine($"= {currentValue}");
        }
        continue;
    }

    switch (input)
    {
        case "+":
        case "-":
        case "*":
        case "/":
        case "%":
        case "^":
            if (!string.IsNullOrEmpty(pendingOperation))
            {
                currentValue = mathOperate(firstNumber, pendingOperation, currentValue);
                Console.WriteLine($"= {currentValue}");
            }
            firstNumber = currentValue;
            pendingOperation = input;
            waitingForSecondNumber = true;
            Console.WriteLine(input);
            break;

        case "x^2":
        case "sqrt":
        case "1/x":
            currentValue = mathOperate(currentValue, input);
            Console.WriteLine($"= {currentValue}");
            break;

        case "M+":
            memory += currentValue;
            Console.WriteLine($"Память: {memory}");
            break;

        case "M-":
            memory -= currentValue;
            Console.WriteLine($"Память: {memory}");
            break;

        case "MR":
            currentValue = memory;
            Console.WriteLine($"= {currentValue} (из памяти)");
            break;

        case "MC":
            memory = 0;
            Console.WriteLine("Память очищена.");
            break;

        case "C":
            currentValue = 0;
            firstNumber = 0;
            pendingOperation = "";
            waitingForSecondNumber = false;
            Console.WriteLine("Экран очищен.");
            Console.WriteLine($"= {currentValue}");
            break;

        default:
            Console.WriteLine("Неизвестная команда.");
            break;
    }
}