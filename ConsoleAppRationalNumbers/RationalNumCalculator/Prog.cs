using System;
using CalcOperations;

namespace RationalNumCalculator
{
    class Prog
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string sourceString = Console.ReadLine();
                string[] separationBySpaces = sourceString.Split(' ');

                if (separationBySpaces.Length == 3)
                {
                    var operation = separationBySpaces[0];
                    var num1 = new Rational();
                    var num2 = num1;

                    if (Rational.TryParse(separationBySpaces[1], out num1)
                     && Rational.TryParse(separationBySpaces[2], out num2))

                        OperationResult(operation, num1, num2);
                    else
                        Console.WriteLine("Invalid string");

                }

                else
                    Console.WriteLine("Not enough data");
            }
        }

        private static void OperationResult(string operation, Rational num1, Rational num2)
        {
            switch (operation)
            {
                case "add":
                    Console.WriteLine(num1.Add(num2));
                    break;
                case "sub":
                    Console.WriteLine(num1.Sub(num2));
                    break;
                case "mul":
                    Console.WriteLine(num1.Multiply(num2));
                    break;
                case "div":
                    Console.WriteLine(num1.DivideBy(num2));
                    break;
                default:
                    Console.WriteLine("Incorrect operation entered");
                    break;
            }
        }
    }
}
