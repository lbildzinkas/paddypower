using System;
using BettingService.Tests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BettingService.Tests
{
    [TestClass]
    public class FractionOddTests
    {
        [TestMethod]
        public void ConvertToDecimal_SimpleFractionOddShouldConvertToDecimalSuccessfully()
        {
            //Arrange
            var odd1 = 10;
            var odd2 = 1;
            var expectedDecimalOdd = 11;
            var fractionOdd = new FractionOdd(odd1, odd2);

            //Act
            var decimalOdd = fractionOdd.ConvertToDecimal();

            //Assert
            Assert.AreEqual(decimalOdd, expectedDecimalOdd);
        }

        [ExpectedException(typeof(DivideByZeroException))]
        [TestMethod]
        public void ConvertToDecimal_FractionOddShouldNotDivideByZero()
        {
            //Arrange
            var odd1 = 10;
            var odd2 = 0;
            var fractionOdd = new FractionOdd(odd1, odd2);

            //Act
            fractionOdd.ConvertToDecimal();
        }

        [TestMethod]
        public void ToString_SimpleFractionOddShouldConvertToStringSuccessfully()
        {
            //Arrange
            var odd1 = 10;
            var odd2 = 1;
            var expectedString = "10/1";
            var fractionOdd = new FractionOdd(odd1, odd2);

            //Act
            var stringOdd = fractionOdd.ToString();

            //Assert
            Assert.AreEqual(stringOdd, expectedString);
        }
    }
}
