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
            return new Complex();
        }

        public Complex DivideBy(Complex x)
        {
            return new Complex();
        }
        /// Вовзращает строковое представление числа в виде R+Ii, где
        /// R и I - строковые представления действительной и мнимой части числа
        /// 'i' - символ, обозначающий мнимую единицу
        /// Если мнимая или действительная часть числа равны нулю, они опускаются
        /// и принимают вид
        /// R (мнимая часть равна 0)
        /// Ii (действительная часть равна 0)
        /// если мнимая часть равна 1, множитель перед 'i' опускается: 1+1i => 1 + i
        public override string ToString()
        {
            return "";
        }


        //Считается ли корректным ввод - add 3+3+5i 4
        //4i+5
        //3+5i+i
        
            //upd: все хуйня

        public static bool TryParse(string input, out Complex result)
        {
            result = new Complex();

            return (IsValidInput(input) 
                && NumberOfValidCharacters(input));
            
        }

        //rename this method
        private static bool NumberOfValidCharacters(string input)
        {
            return input.IndexOf('+') == input.LastIndexOf('+')
                && input.IndexOf('i') == input.LastIndexOf('i')
                && input.IndexOf('-') == input.LastIndexOf('-');
        }

        private static bool IsValidInput(string input)
        {
            return input != null
                && input.Length != 0
                && input[0] != '+'
                && input[0] != '-'
                && input[input.Length - 1] != '+'
                && input[input.Length - 1] != '-'
                && !(input.Contains("i") 
                && input[input.Length - 1] != 'i')
                //&& !input.Contains(" ")
                ;
        }
    }
}
