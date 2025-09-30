using System;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double memory = 0;

            Console.WriteLine("Классический калькулятор на C#");
            double currentResult;

            while (true)
            {
                Console.WriteLine("\nВведите первое число (или 'exit' для выхода):");
                string input = Console.ReadLine();
                if (input?.ToLower() == "exit")
                    break;

                if (!double.TryParse(input, out currentResult))
                {
                    Console.WriteLine("Ошибка: неверный ввод числа.");
                    continue;
                }

                while (true)
                {
                    Console.WriteLine($"\nТекущее число: {currentResult}");
                    Console.WriteLine("Введите операцию (+, -, *, /, %, 1/x, x^2, ^, sqrt, M+, M-, MR, MC, exit):");
                    string op = Console.ReadLine()?.ToLower();

                    switch (op)
                    {
                        case "exit":
                            return;
                        case "c":
                            currentResult = 0;
                            Console.WriteLine("Текущий результат сброшен.");
                            continue;
                    }

                    double secondOperand = 0;
                    bool needSecond = (op == "+" || op == "-" || op == "*" || op == "/" || op == "%" || op == "^");

                    if (needSecond)
                    {
                        Console.WriteLine("Введите второе число:");
                        string secondInput = Console.ReadLine();
                        if (!double.TryParse(secondInput, out secondOperand))
                        {
                            Console.WriteLine("Ошибка: неверный ввод числа.");
                            continue;
                        }
                    }

                    bool operationPerformed = true;
                    double result = currentResult;

                    switch (op)
                    {
                        case "+":
                            result = currentResult + secondOperand;
                            break;
                        case "-":
                            result = currentResult - secondOperand;
                            break;
                        case "*":
                            result = currentResult * secondOperand;
                            break;
                        case "^":
                            result = Math.Pow(currentResult, secondOperand);
                            break;
                        case "/":
                            if (secondOperand == 0)
                            {
                                Console.WriteLine("Ошибка: деление на ноль невозможно.");
                                operationPerformed = false;
                            }
                            else
                                result = currentResult / secondOperand;
                            break;
                        case "%":
                            if (secondOperand == 0)
                            {
                                Console.WriteLine("Ошибка: деление по модулю на ноль невозможно.");
                                operationPerformed = false;
                            }
                            else
                                result = currentResult % secondOperand;
                            break;
                        case "1/x":
                            if (currentResult == 0)
                            {
                                Console.WriteLine("Ошибка: обратное число для 0 не существует.");
                                operationPerformed = false;
                            }
                            else
                                result = 1 / currentResult;
                            break;
                        case "x^2":
                            result = currentResult * currentResult;
                            break;
                        case "sqrt":
                            if (currentResult < 0)
                            {
                                Console.WriteLine("Ошибка: корень квадратный из отрицательного числа невозможен.");
                                operationPerformed = false;
                            }
                            else
                                result = Math.Sqrt(currentResult);
                            break;
                        case "m+":
                            memory += currentResult;
                            Console.WriteLine($"Память увеличена. Текущее значение памяти: {memory}");
                            operationPerformed = false;
                            break;
                        case "m-":
                            memory -= currentResult;
                            Console.WriteLine($"Память уменьшена. Текущее значение памяти: {memory}");
                            operationPerformed = false;
                            break;
                        case "mr":
                            currentResult = memory;
                            Console.WriteLine($"Значение из памяти подставлено: {currentResult}");
                            operationPerformed = false;
                            break;
                        case "mc":
                            memory = 0;
                            Console.WriteLine("Память очищена.");
                            operationPerformed = false;
                            break;
                        default:
                            Console.WriteLine("Ошибка: неизвестная операция.");
                            operationPerformed = false;
                            break;
                    }

                    if (operationPerformed)
                    {
                        currentResult = result;
                        Console.WriteLine($"Результат: {currentResult}");
                    }
                }
            }

            Console.WriteLine("Выход из программы.");
        }
    }
}