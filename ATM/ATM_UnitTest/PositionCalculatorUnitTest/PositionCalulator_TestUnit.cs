using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using ATM;
using TransponderReceiver; 


namespace ATM_UnitTest.PositionCalculatorUnitTest
{
    [TestFixture]
    public class PositionCalulator_TestUnit
    {
        private IPositionCalculator _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new PositionCalculator();
        }

        [Test]
        public void Test_PositionReturnsNord()
        {
            FormattedData test1 = new FormattedData("test1", 1, 1, 0, 0, "Nord", 0);
            string expected = "Nord";

            Assert.That(_uut.CalculatePosition(test1).Equals("Nord"));
           // Assert.AreEqual(expected, _uut.CalculatePosition(test1));
        }
    }
}
