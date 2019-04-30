using System;

namespace Calculator
{
    public class Rational
    {
        public int Numerator { get; set; }

        public int Denominator { get; set; }

        public int Base { get { return (Numerator / Denominator); } }

        public Rational Fraction
        {
            get
            {
                var SubOfWholePart = new Rational();

                SubOfWholePart.Numerator = this.Base;
                SubOfWholePart.Denominator = 1;
                var result = this.Sub(SubOfWholePart);

                return result;
            }
        }   
        
        ///operations
        
        public Rational Add(Rational c)
        {
            var result = new Rational()
            {
                Numerator = this.Numerator * c.Denominator + this.Denominator * c.Numerator,
                Denominator = this.Denominator * c.Denominator
            };

            result.Even();
            return result;
        }

        public Rational Sub(Rational c)
        {
            return this.Add(c.Negate());
        }

        public Rational Negate()
        {
            this.Numerator = -this.Numerator;
            return this;
        }

        public Rational Multiply(Rational x)
        {
            var result = new Rational
            {
                Numerator = this.Numerator * x.Numerator,
                Denominator = this.Denominator * x.Denominator
            };

            result.Even();
            return result;
        }
        public Rational DivideBy(Rational x)
        {
            var result = new Rational
            {
                Numerator = this.Numerator * x.Denominator,
                Denominator = this.Denominator * x.Numerator
            };

            result.Even();
            return result;
        }

        public override string ToString()
        {
            if (this.Denominator == 0)
                return "Division by zero";

            else if (Fraction.Denominator == 1)
                return string.Format("{0}", this.Base);

            else if (Fraction.Numerator == 0)
                return string.Format("0");

            else if (this.Base == 0)
                return string.Format("{0}:{1}", Fraction.Numerator, Fraction.Denominator);

            else
                return string.Format("{0}.{1}:{2}", this.Base, Fraction.Numerator, Fraction.Denominator);
        }


        /// parse data

        public static bool TryParse(string input, out Rational result)
        {
            if (!IsValid(input))
            {
                result = new Rational();
                return false;
            }

            var PartsOfFraction = input.Split(new char[] { '.', ':' }, StringSplitOptions.RemoveEmptyEntries);

            int basePart = 0;
            int num = 0;
            int den = 1;

            if (PartsOfFraction.Length == 3)
            {
                basePart = int.Parse(PartsOfFraction[0]);
                num = int.Parse(PartsOfFraction[1]);
                den = int.Parse(PartsOfFraction[2]);
            }

            else 
            {
                num = int.Parse(PartsOfFraction[0]);
                if (PartsOfFraction.Length == 2)
                    den = int.Parse(PartsOfFraction[1]);
            }

            result = new Rational()
            {
                Numerator = basePart * den + num,
                Denominator = den
            };

            result.Even();

            return true;

        }

        private static bool IsValid(string input)
        {
            var PartsOfFraction = input.Split(new char[] { '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
            return (IsValidInput(input) && PartsOfFraction.Length != 0 && IsValidOrderSeparators(input) && IsValidInputCharacters(input));
        }

        private static bool IsValidInput(string input)
        {
            return input != null
                && input.Length != 0
                && input[0] != ':'
                && input[input.Length - 1] != ':'
                && !input.Contains(" ")
                && input.IndexOf('.') + 1 != input.IndexOf(':')
                && !(!input.Contains(":")
                && input.Contains("."));
        }

        private static bool IsValidOrderSeparators(string input)
        {
            return (input.IndexOf('.') <= input.IndexOf(':'));
        }

        private static bool IsValidInputCharacters(string input)
        {
            foreach (char sym in input)
            {
                if (!(char.IsNumber(sym) || char.IsWhiteSpace(sym) || sym == ':' || sym == '.'))
                    return false;
            }
            return true;
        }
        public static int FindNOD(int num1, int num2)
        {
            while ((num1 != 0) && (num2 != 0))
            {
                if (num1 > num2)
                    num1 -= num2;
                else
                    num2 -= num1;
            }

            return Math.Max(num1, num2);
        }

        public void Even()
        {
            var rational = FindNOD(this.Numerator, this.Denominator);

            try
            {
                this.Numerator /= rational;
                this.Denominator /= rational;
            }

            catch (DivideByZeroException)
            {
                return;
            }
        }
    }
}
