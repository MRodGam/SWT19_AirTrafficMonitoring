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
        private IWriter _writer;
        private ILog _log;

        [SetUp]
        public void SetUp()
        {
            _writer = new LogWriter();
            _log = new ATM.Log(_writer);
            _uut = new SeperationCalculator(_log);
        }

        [Test]
        public void IsAircraftInAirspace_AircraftIsInAirspace_ExpectedTrue()
        {
            FormattedData test1 = new FormattedData("test1", 1, 1, 1, DateTime.Today, "nord", 10);
            _uut.Add(test1);

            FormattedData test2 = new FormattedData("test2", 2, 2, 2, DateTime.Today, "syd", 22);
            _uut.Add(test2);

            FormattedData test3 = new FormattedData("test3", 3, 3, 3, DateTime.Today, "øst", 30);
            _uut.Add(test3);

            Assert.That(_uut.IsAircraftInAirspace(test3)==true);
        }

        [Test]
        public void IsAircraftInAirspace_AircraftIsNotInAirspace_ExpectedFalse()
        {
            FormattedData test1 = new FormattedData("test1", 1, 1, 1, DateTime.Today, "nord", 10);
            _uut.Add(test1);

            FormattedData test2 = new FormattedData("test2", 2, 2, 2, DateTime.Today, "syd", 22);
            _uut.Add(test2);

            FormattedData test3 = new FormattedData("test3", 3, 3, 3, DateTime.Today, "øst", 30);
            _uut.Add(test3);

            FormattedData test4 = new FormattedData("test4", 4, 4, 4, DateTime.Today, "vest", 40);

            Assert.That(_uut.IsAircraftInAirspace(test4) == false);
        }

        [Test]
        public void EvaluateData_AircraftIsInAirspaceWithDifferentPosition_ExpectedTrue()
        {
            FormattedData test1 = new FormattedData("test1", 1, 1, 1, DateTime.Today, "nord", 10);
            _uut.Add(test1);

            FormattedData test2 = new FormattedData("test2", 2, 2, 2, DateTime.Today, "syd", 22);
            _uut.Add(test2);

            FormattedData test3 = new FormattedData("test3", 3, 3, 3, DateTime.Today, "øst", 30);
            _uut.Add(test3);

            FormattedData test1_new = new FormattedData("test1", 4, 4, 4, DateTime.Today, "vest", 40);

            Assert.That(_uut.IsAircraftInAirspace(test1_new) == true);
        }

    }
}
