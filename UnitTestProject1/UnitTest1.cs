using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR4aksenova;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AssertMethods_DemonstrateBasicAssertions()
        {
            int res = 2 + 2;
            Assert.AreEqual(4, res);
            Assert.AreNotEqual(5, res);
            Assert.IsFalse(res > 5);
            Assert.IsTrue(res < 5);
        }

        [TestMethod]
        public void CalculatePage1_ValidInput_ReturnsExpectedValue()
        {
            double x = 2;
            double y = 9;
            double z = 0.3;

            double expected = (Math.Sqrt(y) + Math.Sqrt(x - 1))
                              / Math.Pow(4 * Math.Abs(x - y), 1.0 / 3.0)
                              * (Math.Pow(Math.Sin(z), 2) + Math.Tan(z));

            double actual = MathFunctions.CalculatePage1(x, y, z);

            Assert.AreEqual(expected, actual, 1e-10);
        }


        [TestMethod]
        public void CalculatePage2_SinhBranch_ReturnsExpectedValue()
        {
            double x = 1.2;
            double y = 0.5;

            double fx = Math.Sinh(x);
            double expected = Math.Pow(fx - y, 2) + Math.Cos(y); // x - y > 0

            double actual = MathFunctions.CalculatePage2(x, y, MathFunctions.FxKind.Sinh);

            Assert.AreEqual(expected, actual, 1e-10);
        }

        [TestMethod]
        public void CalculatePage3_ValidInput_ReturnsExpectedValue()
        {
            double x = 2;
            double b = 1;

            double expected = Math.Sqrt(Math.Abs(x - b))
                              / Math.Pow(Math.Abs(Math.Pow(b, 3) - Math.Pow(x, 3)), 1.5)
                              + Math.Log(Math.Abs(x - b));

            double actual = MathFunctions.CalculatePage3(x, b);

            Assert.AreEqual(expected, actual, 1e-10);
        }
    }
}
