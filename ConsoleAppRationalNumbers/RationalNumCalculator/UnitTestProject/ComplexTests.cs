using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace UnitTestProject
{
    [TestClass]
    public class ComplexOperationstest
    {
        [TestMethod]
        public void AddNumber()
        {
            var num1 = new Complex { Real = 1, Imaginary = 3 };
            var num2 = new Complex { Real = 4, Imaginary = -5 };

            var result = num1.Add(num2);

            Assert.AreEqual(5, result.Real);
            Assert.AreEqual(-2, result.Imaginary);
        }


        [TestMethod]
        public void SubNumber()
        {
            var num1 = new Complex { Real = -2, Imaginary = 0 };
            var num2 = new Complex { Real = 6, Imaginary = 5 };

            var result = num1.Sub(num2);

            Assert.AreEqual(-8, result.Real);
            Assert.AreEqual(-5, result.Imaginary);
        }


        [TestMethod]
        public void NegateNumber()
        {
            var num1 = new Complex { Real = 1, Imaginary = -3 };

            var result = num1.Negate();

            Assert.AreEqual(-1, result.Real);
            Assert.AreEqual(3, result.Imaginary);
        }

    }
}
