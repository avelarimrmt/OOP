using System;
using CalcOperations;

namespace RationalNumCalculator
{
    class Prog
    {
        static void Main(string[] args)
        {
            var operation = (Console.ReadLine());
            var num1 = new Rational();
            var num2 = num1;
            Rational.TryParse(Console.ReadLine(), out num1);
            Rational.TryParse(Console.ReadLine(), out num2);


            switch (operation)
            {
                case "add":
                    var result = num1.Add(num2);
                    Console.WriteLine(result);
                    break;
                case "sub":
                    result = num1.Sub(num2);
                    Console.WriteLine(result);
                    break;
                case "mul":
                    result = num1.Multiply(num2);
                    Console.WriteLine(result);
                    break;
                case "div":
                    result = num1.DivideBy(num2);
                    Console.WriteLine(result);
                    break;
            }
        }
    }
}
