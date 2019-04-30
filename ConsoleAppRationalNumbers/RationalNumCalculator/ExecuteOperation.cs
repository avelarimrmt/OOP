using System;
using System.Collections.Generic;
using Calculator;

namespace ConsoleApplication
{
    public class ExecuteOperation
    {

        /// <summary>
        /// Избавиться от дублирования, если возможно
        /// </summary>
        /// 
        private static Dictionary<string, Func<Complex, Complex, Complex>> operationsComplex =
new Dictionary<string, Func<Complex, Complex, Complex>>
{
        { "add", (x, y) => x.Add(y) },
        { "sub", (x, y) => x.Sub(y) },
        { "mul", (x, y) => x.Multiply(y) },
        { "div", (x, y) => x.DivideBy(y) },
};

        private static Dictionary<string, Func<Rational, Rational, Rational>> operationsRational =
new Dictionary<string, Func<Rational, Rational, Rational>>
{
        { "add", (x, y) => x.Add(y) },
        { "sub", (x, y) => x.Sub(y) },
        { "mul", (x, y) => x.Multiply(y) },
        { "div", (x, y) => x.DivideBy(y) },
};

        public static void Rational(string op, Rational num1, Rational num2)
        {
            if (!operationsRational.ContainsKey(op))
                throw new ArgumentException(string.Format("Operation {0} is invalid", op), "op");
            Console.WriteLine(operationsRational[op](num1, num2));
        }

        public static void Complex(string op, Complex num1, Complex num2)
        {
            if (!operationsComplex.ContainsKey(op))
                throw new ArgumentException(string.Format("Operation {0} is invalid", op), "op");
            Console.WriteLine(operationsComplex[op](num1, num2));
        }
    }
}
