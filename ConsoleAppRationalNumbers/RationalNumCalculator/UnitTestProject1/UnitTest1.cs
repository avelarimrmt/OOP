using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace UnitTestProject
{
    [TestClass]
    class ComplexOperationstest
    {
        [TestMethod]
        public void AddNumber()
        {
            var num1 = new Complex { Real = 1, Imaginary = 4 };
            var num2 = new Complex { Real = 3, Imaginary = -5 };

            var result = num1.Add(num2);

            Assert.AreEqual(5, result.Real);
            Assert.AreEqual(-2, result.Imaginary);
        }

    }
}
