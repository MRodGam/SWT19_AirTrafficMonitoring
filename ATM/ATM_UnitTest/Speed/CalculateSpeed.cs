using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using ATM;

namespace ATM_UnitTest.Speed
{
    [TestFixture]
    public class CalculateSpeed
    {
        private ISpeedCalculator _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new SpeedCalculator();
        }

        //[Test]
        //public void Speed_ExpectedToTrue()
        //{
            
        //    FormattedData currentData = new FormattedData("Current data", 20000, 1000, 2000, "2019-03-19 13:21:21", "South", 10);
        //    FormattedData oldData = new FormattedData("Old data", 20000, 1000, 2000, "2019-03-19 14:32:25", "East", 50);

       
        //    Assert.AreEqual(_uut.CalculateSpeed(currentData, oldData), 1);



        //}
    }
}
