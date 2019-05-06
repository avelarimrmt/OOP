using System;


namespace Calculator
{
    public class Complex
    {
        public double Real { get; set; }

        public double Imaginary { get; set; }

        public double Measure { get { return Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2)); } }

        public double Angle { get { return Math.Tan(Imaginary / Real); } }


        //operations

        public Complex Add(Complex c)
        {
            return new Complex()
            { Real = this.Real + c.Real, Imaginary = this.Imaginary + c.Imaginary };
        }

        public Complex Negate()
        {
            return new Complex()
            { Real = -this.Real, Imaginary = -this.Imaginary };
        }

        public Complex Sub(Complex c)
        {
            return this.Add(c.Negate());
        }

        public Complex Multiply(Complex x)
        {
            return new Complex()
            {
                Real = this.Real * x.Real - this.Imaginary * x.Imaginary,
                Imaginary = this.Real * x.Imaginary + x.Real * this.Imaginary
            };
        }

        public Complex DivideBy(Complex x)
        {
            return new Complex()
            {
                Real = (this.Real * x.Real + this.Imaginary * x.Imaginary) / (x.Real * x.Real + x.Imaginary * x.Imaginary),
                Imaginary = (x.Real * this.Imaginary - this.Real * x.Imaginary) / (x.Real * x.Real + x.Imaginary * x.Imaginary)
            };
        }
        public override string ToString()
        {
            string output;


            if (Measure == 0)
                output = "0";

            else if (Imaginary == 0)
                output = Real.ToString();

            else if (Real == 0)
                output = string.Format("{0}i", Imaginary);

            else if (Math.Sign(Imaginary) > 0)
                output = string.Format("{0}+{1}i", Real, Imaginary);

            else
                output = string.Format("{0}{1}i", Real, Imaginary);


            if (Math.Abs(Imaginary) == 1)
                output = output.Remove(output.Length - 2, 1);

            return output;
        }


        public static bool TryParse(string input, out Complex result)
        {
            result = new Complex();

            if (!IsValid(input))
                return false;


            var partsOfInput = input.Split(new char[] { '+', '-', 'i' }, StringSplitOptions.RemoveEmptyEntries);

            double real = 0, imaginary = 0;

            if (partsOfInput.Length == 2)
            {
                real = double.Parse(partsOfInput[0]);
                imaginary = double.Parse(partsOfInput[1]);
            }

            else if (input.Contains("i"))
            {
                try
                {
                    imaginary = double.Parse(partsOfInput[0]);
                }

                catch (IndexOutOfRangeException)
                {
                    imaginary = 1;
                }
            }

            else
                real = double.Parse(partsOfInput[0]);

            RestoreSigns(ref real, ref imaginary, input);


            result = new Complex { Real = real, Imaginary = imaginary};

            return true;
        }

        private static void RestoreSigns(ref double real, ref double imaginary, string input)
        {
            if (input.Contains("-"))
            {
                real = -real; imaginary = -imaginary;

                if (input.Contains("+"))
                    imaginary = -imaginary;

                if (input[0] != '-')
                    real = -real;
            }
        }

        private static bool IsValid(string input)
        {
            var partsOfInput = input.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);

            return (IsValidInput(input)
                && IsValidOrderOfSigns(input)
                && IsValidSymbols(input))
                && partsOfInput.Length < 3;
        }

        private static bool IsValidInput(string input)
        {
            return !string.IsNullOrEmpty(input)
                && input[0] != '+'
                && input[input.Length - 1] != '+'
                && input[input.Length - 1] != '-'

                && !(input.Contains("i")
                && input[input.Length - 1] != 'i')

                && input.IndexOf('i') == input.LastIndexOf('i')

                && !input.Contains(" ");
        }

        private static bool IsValidOrderOfSigns(string input)
        {
            var partsOfInput = input.Split(new char[] { '+', '-' }, StringSplitOptions.None);

            for (int i = 1; i < partsOfInput.Length; i++)
                if (string.IsNullOrEmpty(partsOfInput[i]))

                    return false;

            return true;
        }

        private static bool IsValidSymbols(string input)
        {
            var PartsOfFraction = input.Split(new char[] { '+', '-', 'i' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string number in PartsOfFraction)
            {
                try
                {
                    double.Parse(number);
                }

                catch (FormatException)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
