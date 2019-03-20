using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using NSubstitute;
using ATM;
using TransponderReceiver;

namespace ATM_UnitTest
{
    [TestFixture]
    class EvaluateData
    {
        private ISeperationCalculator _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new SeperationCalculator();
        }

        [Test]
        public void IsAircraftInAirspace_AircraftIsInAirspace_ExpectedTrue()
        {
            FormattedData test1 = new FormattedData("test1", 1, 1, 1, "1200", "nord", 10);
            _uut.Add(test1);

            FormattedData test2 = new FormattedData("test2", 2, 2, 2, "2200", "syd", 22);
            _uut.Add(test2);

            FormattedData test3 = new FormattedData("test3", 3, 3, 3, "3300", "øst", 30);
            _uut.Add(test3);

            Assert.That(_uut.IsAircraftInAirspace(test3)==true);
        }

        [Test]
        public void IsAircraftInAirspace_AircraftIsNotInAirspace_ExpectedFalse()
        {
            FormattedData test1 = new FormattedData("test1", 1, 1, 1, "1200", "nord", 10);
            _uut.Add(test1);

            FormattedData test2 = new FormattedData("test2", 2, 2, 2, "2200", "syd", 22);
            _uut.Add(test2);

            FormattedData test3 = new FormattedData("test3", 3, 3, 3, "3300", "øst", 30);
            _uut.Add(test3);

            FormattedData test4 = new FormattedData("test4", 4, 4, 4, "4400", "vest", 40);

            Assert.That(_uut.IsAircraftInAirspace(test4) == false);
        }

        [Test]
        public void EvaluateData_AircraftIsInAirspaceWithDifferentPosition_ExpectedTrue()
        {
            FormattedData test1 = new FormattedData("test1", 1, 1, 1, "1200", "nord", 10);
            _uut.Add(test1);

            FormattedData test2 = new FormattedData("test2", 2, 2, 2, "2200", "syd", 22);
            _uut.Add(test2);

            FormattedData test3 = new FormattedData("test3", 3, 3, 3, "3300", "øst", 30);
            _uut.Add(test3);

            FormattedData test1_new = new FormattedData("test1", 4, 4, 4, "4400", "vest", 40);

            Assert.That(_uut.IsAircraftInAirspace(test1_new) == true);
        }

    }
}
