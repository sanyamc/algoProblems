using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitExplorations
{
    [TestClass]
    public class Bitwise
    {
        [TestMethod]
        public void LeftShiftBasic()
        {
            // a bit can be left shifted to produce a new number
            // number << toshiftby
            Assert.IsTrue(1 << 1 == 2);
            Assert.IsTrue(1 << 2 == 4);

            Console.WriteLine((1 << 2) & 4);

            Assert.IsTrue(((1 << 2) & 4) == 4); // & results in same number

            var k = 3;
            Assert.IsTrue(((1 << k) | 2) == 10); // settin kth bith using left shift

        }
    }
}
