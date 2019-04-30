using System;
using Calculator;

namespace Application
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
                    Console.WriteLine("Incorrect input");

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
                        ExecuteOperation.Complex(operation, num1, num2);
                    }
                }
            }
        }
    }
}