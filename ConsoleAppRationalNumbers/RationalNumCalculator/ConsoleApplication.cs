using System;
using Calculator;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            for (;;)
            {
                //Parse
                string sourceString = Console.ReadLine();
                string[] separationBySpaces = sourceString.Split(' ');

                if (separationBySpaces.Length != 3)
                    Console.WriteLine("Not enough data");

                else
                {
                    //Rational num1, num2;
                    Complex num1, num2;

                    //if (!Rational.TryParse(separationBySpaces[1], out num1)
                    //            || !Rational.TryParse(separationBySpaces[2], out num2))

                    if (!Complex.TryParse(separationBySpaces[1], out num1)
                                || !Complex.TryParse(separationBySpaces[2], out num2))
                        Console.WriteLine("Invalid string");
                    
                    //Execute

                    else
                    {
                        var operation = separationBySpaces[0];
                        //ExecuteOperation.Rational(operation, num1, num2);
                        ExecuteOperation.Complex(operation, num1, num2);
                    }

                }
            }
        }
    }
}