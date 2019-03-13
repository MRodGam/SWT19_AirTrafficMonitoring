using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using ATM;

namespace ATM_UnitTest.position_speed
{
    [TestFixture]
    public class PositionCalculatorTestUnit
    {
        private IPositionCalculator _uut;

        [SetUp]
        public void SetUp()
        {

        }

        [TestCase(89,60, "Øst")]
        [TestCase(71, 71, "Øst")]
        [TestCase(71, -71, "Øst")]
        public void Test_Coordinate_Returns_Øst(int x, int y, string expectedCourse)
        {
            FormattedData currentData = new FormattedData("test", x,y,0,"0","",0);
            Assert.That(_uut.CalculatePosition(currentData) == expectedCourse);
        }
        

    } 
}
