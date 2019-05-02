using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace UnitTestProject
{
    [TestClass]
    public class ComplexTest
    {

        //operations

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



        ///Try Parse

        [TestMethod]
        public void StartsInPlus()
        {
            var num = new Complex();
            var result = Complex.TryParse("+4i", out num);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void EndsInPlus()
        {
            var num = new Complex();
            var result = Complex.TryParse("2+", out num);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestParse1()
        {
            var num = new Complex();
            var result = Complex.TryParse("2i7", out num);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EmptyString()
        {
            var num = new Complex();
            var result = Complex.TryParse("", out num);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SeveralPluses()
        {
            var num = new Complex();
            var result = Complex.TryParse("2+3+4i", out num);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SeveralValidCharacters()
        {
            var num = new Complex();
            var result = Complex.TryParse("3i+4i", out num);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SeveralPoints1()
        {
            var num = new Complex();
            var result = Complex.TryParse("3.6.534.5+5i", out num);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SeveralPoints2()
        {
            var num = new Complex();
            var result = Complex.TryParse(".+5i", out num);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SeveralMinuses()
        {
            var num = new Complex();
            var result = Complex.TryParse("--4-5i", out num);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SeveralDidgitParts()
        {
            var num = new Complex();
            var result = Complex.TryParse("34-54+5i", out num);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InvalidCharacters()
        {
            var num = new Complex();
            var result = Complex.TryParse("34.u+6i", out num);
            Assert.IsFalse(result);
        }


        //ToString

        [TestMethod]
        public void ToString1()
        {
            var num = new Complex()
            { Real = 0, Imaginary = 0 };

            var result = num.ToString();
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void ToString2()
        {
            var num = new Complex()
            { Real = -8, Imaginary = 0};

            var result = num.ToString();
            Assert.AreEqual("-8", result);
        }

        [TestMethod]
        public void ToString3()
        {
            var num = new Complex()
            { Real = 0, Imaginary = -7 };

            var result = num.ToString();
            Assert.AreEqual("-7i", result);
        }

        [TestMethod]
        public void ToString4()
        {
            var num = new Complex()
            { Real = -8, Imaginary = -7 };

            var result = num.ToString();
            Assert.AreEqual("-8-7i", result);
        }

        [TestMethod]
        public void ToString5()
        {
            var num = new Complex()
            { Real = 8, Imaginary = 7 };

            var result = num.ToString();
            Assert.AreEqual("8+7i", result);
        }

        [TestMethod]
        public void ToString6()
        {
            var num = new Complex()
            { Real = 8, Imaginary = 1 };

            var result = num.ToString();
            Assert.AreEqual("8+i", result);
        }

        [TestMethod]
        public void ToString7()
        {
            var num = new Complex()
            { Real = 0, Imaginary = -1 };

            var result = num.ToString();
            Assert.AreEqual("-i", result);
        }


        //valid input

        [TestMethod]
        public void CorrectInput1()
        {
            var num = new Complex();
            var result = Complex.TryParse("2+4i", out num);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CorrectInput2()
        {
            var num = new Complex();
            var result = Complex.TryParse("2", out num);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CorrectInput3()
        {
            var num = new Complex();
            var result = Complex.TryParse("-4.8i", out num);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CorrectInput4()
        {
            var num = new Complex();
            var result = Complex.TryParse("88-5.7i", out num);
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void CorrectInput5()
        {
            var num = new Complex();
            var result = Complex.TryParse("i", out num);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CorrectInput6()
        {
            var num = new Complex();
            var result = Complex.TryParse("88,6-5,7i", out num);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CorrectInput7()
        {
            var num = new Complex();
            var result = Complex.TryParse("3+i", out num);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CorrectInput8()
        {
            var num = new Complex();
            var result = Complex.TryParse("-9-9i", out num);
            Assert.IsTrue(result);
        }
    }
}
