using System;
using System.Collections.Generic;
using System.Linq;

namespace KalkulatorApp
{
    public class CalculatorService
    {
        private readonly ScientificCalculator scientificCalculator;
        private readonly Calculator calculator;

        public CalculatorService()
        {
            calculator = new Calculator();
            scientificCalculator = new ScientificCalculator(calculator);
        }

        public void Initialize()
        {
            while (true)
            {
                Console.WriteLine("\nOperacje do wyboru: +, -, *, /, ^, sqrt, log, sum, avg, max, min lub 'exit' by zakończyć:");
                var choice = Console.ReadLine()?.Trim();

                if (choice == "exit")
                    break;

                try
                {
                    switch (choice)
                    {
                        case "+":
                        case "-":
                        case "*":
                        case "/":
                        case "^":
                            Console.Write("Podaj pierwsza liczba: ");
                            double a = double.Parse(Console.ReadLine());

                            Console.Write("Podaj druga liczba: ");
                            double b = double.Parse(Console.ReadLine());

                            double result = choice switch
                            {
                                "+" => calculator.Add(a, b),
                                "-" => calculator.Subtract(a, b),
                                "*" => calculator.Multiply(a, b),
                                "/" => calculator.Divide(a, b),
                                "^" => scientificCalculator.Power(a, b),
                                _ => throw new InvalidOperationException()
                            };

                            Console.WriteLine("Wynik: " + result);
                            break;

                        case "sqrt":
                            Console.Write("Podaj liczbe: ");
                            double sqrtInput = double.Parse(Console.ReadLine());
                            Console.WriteLine("Pierwiastek: " + scientificCalculator.SquareRoot(sqrtInput));
                            break;

                        case "log":
                            Console.Write("Podaj liczbe: ");
                            double logInput = double.Parse(Console.ReadLine());
                            Console.WriteLine("Logarytm: " + scientificCalculator.Log(logInput));
                            break;

                        case "sum":
                        case "avg":
                        case "max":
                        case "min":
                            Console.Write("Podaj liczby oddzielone spacja: ");
                            var input = Console.ReadLine()?.Split();
                            var numbers = input.Select(double.Parse).ToList();

                            double aggregateResult = choice switch
                            {
                                "sum" => scientificCalculator.SumSequence(numbers),
                                "avg" => scientificCalculator.Average(numbers),
                                "max" => scientificCalculator.MaximumNum(numbers),
                                "min" => scientificCalculator.MinimumNum(numbers),
                                _ => throw new InvalidOperationException()
                            };

                            Console.WriteLine("Wynik: " + aggregateResult);
                            break;

                        default:
                            Console.WriteLine("Nieznana operacja");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Blad: " + e.Message);
                }
            }
        }
    }
}
