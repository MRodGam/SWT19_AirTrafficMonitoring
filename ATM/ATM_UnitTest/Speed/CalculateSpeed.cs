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

        [Test]

        public void Speed_ExpectedToTrue()
        {
            //double distance = 1000;
            //double time = 1;
        }
    }
}
