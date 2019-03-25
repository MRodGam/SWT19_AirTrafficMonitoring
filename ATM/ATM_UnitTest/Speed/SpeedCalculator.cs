using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using ATM;
using NUnit.Framework.Internal;

namespace ATM_UnitTest.Speed
{
    [TestFixture]
    public class SpeedCalculator
    {
        private ISpeedCalculator _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new ATM.SpeedCalculator();
        }

        [Test]
        public void Speed_ExpectedTrue_OneMinute()
        {
            DateTime dateTime1 = new DateTime(2019, 03, 24, 21, 48, 20, 034);
            DateTime dateTime2 = new DateTime(2019, 03, 24, 21, 47, 20, 034);

            FormattedData currentData = new FormattedData("Current data", 20000, 1000, 2000, dateTime1, "South", 0);
            FormattedData oldData = new FormattedData("Old data", 150, 50, 500, dateTime2, "South", 0);
            
            double expected = 332.154;

            double actual = _uut.CalculateSpeed(currentData, oldData);

            Assert.AreEqual(expected, actual);

            
        }

        [Test]
        public void Speed_ExpectedTrue_TenMinutes()
        {
            
            DateTime dateTime1 = new DateTime(2019, 03, 24, 21, 48, 20, 034);
            DateTime dateTime2 = new DateTime(2019, 03, 24, 21, 38, 20, 034);

            FormattedData currentData = new FormattedData("Current data", 300000, 200000, 20000, dateTime1, "South", 0);
            FormattedData oldData = new FormattedData("Old data", 1000, 10000, 10000, dateTime2, "South", 0);

            double expected = 590.671;

            double actual = _uut.CalculateSpeed(currentData, oldData);

            Assert.AreEqual(expected, actual);

            //Assert.AreEqual(_uut.CalculateSpeed(currentData, oldData), 0);
      
        }
        [Test]
        public void Speed_ExpectedTrue_OneHour()
        {

            DateTime dateTime1 = new DateTime(2019, 03, 24, 22, 48, 20, 034);
            DateTime dateTime2 = new DateTime(2019, 03, 24, 21, 48, 20, 034);

            FormattedData currentData = new FormattedData("Current data", 300000, 300000, 2000, dateTime1, "South", 0);
            FormattedData oldData = new FormattedData("Old data", 0, 0, 500, dateTime2, "South", 0);

            double expected = 117.852;

            double actual = _uut.CalculateSpeed(currentData, oldData);

            Assert.AreEqual(expected, actual);

            //Assert.AreEqual(_uut.CalculateSpeed(currentData, oldData), 0);

        }
        [Test]
        public void CalculateHours_ExpectedMinuteInSecondsTrue()
        {

            DateTime dateTime1 = new DateTime(2019, 03, 24, 21, 48, 20, 034);
            DateTime dateTime2 = new DateTime(2019, 03, 24, 21, 47, 20, 034);

            FormattedData currentData = new FormattedData("Current data", 20000, 1000, 2000, dateTime1, "South", 2000);
            FormattedData oldData = new FormattedData("Old data", 10000, 100, 1000, dateTime2, "South", 10000);

            double expected = 60;

            double actual = _uut.CalculateHours(currentData, oldData);

            Assert.AreEqual(expected, actual);

            
        }
        [Test]
        public void CalculateHours_TenMinutesInSeconds_ExpectedTrue()
        {

            DateTime dateTime1 = new DateTime(2019, 03, 24, 21, 48, 20, 034);
            DateTime dateTime2 = new DateTime(2019, 03, 24, 21, 38, 20, 034);

            FormattedData currentData = new FormattedData("Current data", 20000, 1000, 2000, dateTime1, "South", 2000);
            FormattedData oldData = new FormattedData("Old data", 10000, 100, 1000, dateTime2, "South", 10000);

            double expected = 600;

            double actual = _uut.CalculateHours(currentData, oldData);

            Assert.AreEqual(expected, actual);


        }
        [Test]
        public void CalculateHours_ExpectedHourInSecondsTrue()
        {

            DateTime dateTime1 = new DateTime(2019, 03, 24, 22, 48, 20, 034);
            DateTime dateTime2 = new DateTime(2019, 03, 24, 21, 48, 20, 034);

            FormattedData currentData = new FormattedData("Current data", 20000, 1000, 2000, dateTime1, "South", 2000);
            FormattedData oldData = new FormattedData("Old data", 10000, 100, 1000, dateTime2, "South", 10000);

            double expected = 3600;

            double actual = _uut.CalculateHours(currentData, oldData);

            Assert.AreEqual(expected, actual);


        }


    }
    
}
