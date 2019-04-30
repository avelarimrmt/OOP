using System;
using CalcOperations;
using System.Collections.Generic;

namespace RationalNumCalculator
{
    class Prog
    {
        private static Dictionary<string, Func<Rational, Rational, Rational>> operations =
        new Dictionary<string, Func<Rational, Rational, Rational>>
        {
        { "add", (x, y) => x.Add(y) },
        { "sub", (x, y) => x.Sub(y) },
        { "mul", (x, y) => x.Multiply(y) },
        { "div", (x, y) => x.DivideBy(y) },
        };
        static void Main(string[] args)
        {
            while (true)
            {
                string sourceString = Console.ReadLine();
                string[] separationBySpaces = sourceString.Split(' ');

                if (separationBySpaces.Length != 3)
                {
                    Console.WriteLine("Not enough data");
                    continue;
                }

                var operation = separationBySpaces[0];

                var num1 = new Rational();
                var num2 = num1;
                if (!Rational.TryParse(separationBySpaces[1], out num1)
                    || !Rational.TryParse(separationBySpaces[2], out num2))
                {
                    Console.WriteLine("Invalid string");
                    continue;
                }

                OperationResult(operation, num1, num2);
            }
        }
        private static void OperationResult(string op, Rational num1, Rational num2)
        {
            if (!operations.ContainsKey(op))
                throw new ArgumentException(string.Format("Operation {0} is invalid", op), "op");
            Console.WriteLine(operations[op](num1, num2));
        }
    }
}