using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace UnitTestProject
{
    [TestClass]
    public class RationalTests
    {
        [TestMethod]
        public void NumbersAreZero()
        {
            var num1 = new Rational { Numerator = 0, Denominator = 1 };
            var num2 = num1;
            var result = num1.Add(num2);
            Assert.AreEqual(0, result.Numerator);
            Assert.AreEqual(1, result.Denominator);
        }
        [TestMethod]
        public void SameDenominators()
        {
            var num1 = new Rational { Numerator = 1, Denominator = 2 };
            var num2 = new Rational { Numerator = 2, Denominator = 2 };
            var result = num1.Add(num2);
            Assert.AreEqual(3, result.Numerator);
            Assert.AreEqual(2, result.Denominator);
        }
        [TestMethod]
        public void BaseTest()
        {
            var num1 = new Rational { Numerator = 5, Denominator = 2 };
            var result = num1.Base;
            Assert.AreEqual(2, result);

        }
        [TestMethod]
        public void FractionTest()
        {
            var num1 = new Rational { Numerator = 5, Denominator = 2 };
            var result = num1.Fraction;
            Assert.AreEqual(1, result.Numerator);
            Assert.AreEqual(2, result.Denominator);
        }
        [TestMethod]
        public void DifferentDenominators()
        {
            var num1 = new Rational { Numerator = 1, Denominator = 2 };
            var num2 = new Rational { Numerator = 2, Denominator = 3 };
            var result = num1.Add(num2);
            Assert.AreEqual(7, result.Numerator);
            Assert.AreEqual(6, result.Denominator);
        }
        [TestMethod]
        public void NegateTest()
        {
            var num1 = new Rational { Numerator = 1, Denominator = 2 };
            var result = num1.Negate();
            Assert.AreEqual(-1, result.Numerator);
            Assert.AreEqual(2, result.Denominator);
        }
        [TestMethod]
        public void SubTest()
        {
            var num1 = new Rational { Numerator = 5, Denominator = 6 };
            var num2 = new Rational { Numerator = 1, Denominator = 6 };
            var result = num1.Sub(num2);
            Assert.AreEqual(2, result.Numerator);
            Assert.AreEqual(3, result.Denominator);
        }
        [TestMethod]
        public void MultiplyTest()
        {
            var num1 = new Rational { Numerator = 1, Denominator = 2 };
            var num2 = new Rational { Numerator = 2, Denominator = 7 };
            var result = num1.Multiply(num2);
            Assert.AreEqual(1, result.Numerator);
            Assert.AreEqual(7, result.Denominator);
        }
        [TestMethod]
        public void DivideByTest()
        {
            var num1 = new Rational { Numerator = 2, Denominator = 3 };
            var num2 = new Rational { Numerator = 5, Denominator = 6 };
            var result = num1.DivideBy(num2);
            Assert.AreEqual(4, result.Numerator);
            Assert.AreEqual(5, result.Denominator);
        }
        [TestMethod]
        public void ToStringTest1()
        {
            var num1 = new Rational { Numerator = 5, Denominator = 4 };
            var result = num1.ToString();
            Assert.AreEqual("1.1:4", result);
        }
        [TestMethod]
        public void ToStringTest2()
        {
            var num1 = new Rational { Numerator = 0, Denominator = 4 };
            var result = num1.ToString();
            Assert.AreEqual("0", result);
        }
        [TestMethod]
        public void ToStringTest3()
        {
            var num1 = new Rational { Numerator = 2, Denominator = 1 };
            var result = num1.ToString();
            Assert.AreEqual("2", result);
        }
        [TestMethod]
        public void ToStringTest4()
        {
            var num1 = new Rational { Numerator = 6, Denominator = 2 };
            var result = num1.ToString();
            Assert.AreEqual("3", result);
        }
        [TestMethod]
        public void ToStringTest5()
        {
            var num1 = new Rational { Numerator = 1, Denominator = 2 };
            var result = num1.ToString();
            Assert.AreEqual("1:2", result);
        }
        [TestMethod]
        public void TryParseTest1()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse("5.0:5", out result);
            Assert.IsTrue(Success);

            Assert.AreEqual(5, result.Numerator);
            Assert.AreEqual(1, result.Denominator);
        }
        [TestMethod]
        public void TryParseTest2()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse("1.2:5", out result);
            Assert.IsTrue(Success);

            Assert.AreEqual(7, result.Numerator);
            Assert.AreEqual(5, result.Denominator);
        }
        [TestMethod]
        public void TryParseTest()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse("2.3:4", out result);
            Assert.IsTrue(Success);

            Assert.AreEqual(11, result.Numerator);
            Assert.AreEqual(4, result.Denominator);
        }
        [TestMethod]
        public void TryParseTest14()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse("2.5:1", out result);
            Assert.IsTrue(Success);

            Assert.AreEqual(7, result.Numerator);
            Assert.AreEqual(1, result.Denominator);
        }
        [TestMethod]
        public void TryParseTest3()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse("2:1", out result);
            Assert.IsTrue(Success);

            Assert.AreEqual(2, result.Numerator);
            Assert.AreEqual(1, result.Denominator);
        }
        [TestMethod]
        public void TryParseTest4()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse("5:6", out result);
            Assert.IsTrue(Success);

            Assert.AreEqual(5, result.Numerator);
            Assert.AreEqual(6, result.Denominator);
        }
        [TestMethod]
        public void TryParseTest5()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse("5", out result);
            Assert.IsTrue(Success);

            Assert.AreEqual(5, result.Numerator);
            Assert.AreEqual(1, result.Denominator);
        }
        [TestMethod]
        public void TryParseTest6()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse("3:9", out result);
            Assert.IsTrue(Success);

            Assert.AreEqual(1, result.Numerator);
            Assert.AreEqual(3, result.Denominator);
        }
        [TestMethod]
        public void TryParseTest7()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse("", out result);
            Assert.IsFalse(Success);
        }
        [TestMethod]
        public void TryParseTest15()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse(":", out result);
            Assert.IsFalse(Success);
        }
        [TestMethod]
        public void TryParseTest8()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse(":2", out result);
            Assert.IsFalse(Success);
        }
        [TestMethod]
        public void NotOrderSeparators1()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse("2:5.2", out result);
            Assert.IsFalse(Success);
        }
        [TestMethod]
        public void NotOrderSeparators2()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse("2:.2", out result);
            Assert.IsFalse(Success);
        }
        [TestMethod]
        public void TryParseTest11()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse("2.:2", out result);
            Assert.IsFalse(Success);
        }
        [TestMethod]
        public void TryParseTest12()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse("2.2", out result);
            Assert.IsFalse(Success);
        }

        [TestMethod]
        public void TryParseTest16()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse("2.", out result);
            Assert.IsFalse(Success);
        }

        [TestMethod]
        public void TryParseTest13()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse("2.2:", out result);
            Assert.IsFalse(Success);
        }
        [TestMethod]
        public void TryParseTestSpaces()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse("2.2:5  ", out result);
            Assert.IsFalse(Success);
        }
        [TestMethod]
        public void TryParseTestSpaces1()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse("2  2", out result);
            Assert.IsFalse(Success);
        }

        [TestMethod]
        public void EvenTest()
        {
            var num1 = new Rational { Numerator = 8, Denominator = 12 };
            num1.Even();
            Assert.AreEqual(2, num1.Numerator);
            Assert.AreEqual(3, num1.Denominator);
        }
        [TestMethod]
        public void FindNODTest()
        {
            var num1 = 12;
            var num2 = 24;
            var result = Rational.FindNOD(num1, num2);
            Assert.AreEqual(12, result);
        }
        [TestMethod]
        public void EnteringOtherCharacters()
        {
            Rational result = new Rational();
            var Success = Rational.TryParse("adf", out result);
            Assert.IsFalse(Success);
        }
    }
}
