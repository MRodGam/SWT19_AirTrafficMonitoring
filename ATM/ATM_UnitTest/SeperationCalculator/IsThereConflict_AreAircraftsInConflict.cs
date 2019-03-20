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
    class IsThereConflict_AreAircraftsInConflict
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
        public void AreAircraftsInConflict_ManualInput_ExpectedTrue()
        {
            FormattedData test1 = new FormattedData("Test1",20000,20000,2000, DateTime.Today, "Nord",0);
            FormattedData test2 = new FormattedData("Test2",16000,16000,1800, DateTime.Today, "Nord",0);

            Assert.That(_uut.AreAircraftsInConflict(test1, test2) == true);
        }

        [Test]
        public void AreAircraftsInConflict_ManualInputTestOfAbsValue_ExpectedTrue()
        {
            FormattedData test1 = new FormattedData("Test2", 16000, 16000, 1800, DateTime.Today, "Nord", 0);
            FormattedData test2 = new FormattedData("Test1", 20000, 20000, 2000, DateTime.Today, "Nord", 0);

            Assert.That(_uut.AreAircraftsInConflict(test1, test2) == true);
        }

        [Test]
        public void AreAircraftsInConflict_ManualInput_ExpectedFalse()
        {
            FormattedData test1 = new FormattedData("Test1", 20000, 2000, 2000, DateTime.Today, "Nord", 0);
            FormattedData test2 = new FormattedData("Test2", 26000, 2600, 2500, DateTime.Today, "Nord", 0);

            Assert.That(_uut.AreAircraftsInConflict(test1, test2) == false);
        }

        [Test]
        public void AreAircraftsInConflict_ManualInputTestOfAbsValue_ExpectedFalse()
        {
            FormattedData test1 = new FormattedData("Test2", 26000, 26000, 2500, DateTime.Today, "Nord", 0);
            FormattedData test2= new FormattedData("Test1", 20000, 20000, 2000, DateTime.Today, "Nord", 0);

            Assert.That(_uut.AreAircraftsInConflict(test1, test2) == false);
        }

        [Test]
        public void IsThereConflict_ExpectedTrue()
        {
            FormattedData test1 = new FormattedData("Test1", 20000, 20000, 2000, DateTime.Today, "Nord", 0);
            FormattedData test2 = new FormattedData("Test2", 16000, 16000, 1800, DateTime.Today, "Nord", 0);

            Assert.That(_uut.AreAircraftsInConflict(test1, test2) == true);
        }


        [Test]
        public void AreAircraftsInConflict_InputThroughList_ExpectedTrue()
        {
            FormattedData test1 = new FormattedData("Test1", 20000, 20000, 2000, DateTime.Today, "Nord", 0);
            _uut.Add(test1);

            FormattedData test2 = new FormattedData("Test2", 16000, 16000, 1800, DateTime.Today, "Nord", 0);
            _uut.Add(test2);

            Assert.That(_uut.IsThereConflict(test1) == true);
        }

        [Test]
        public void AreAircraftsInConflict_InputThroughList_ExpectedFalse()
        {
            FormattedData test1 = new FormattedData("Test1", 30000, 30000, 3000, DateTime.Today, "Nord", 0);
            _uut.Add(test1);

            FormattedData test2 = new FormattedData("Test2", 16000, 16000, 1800, DateTime.Today, "Nord", 0);
            _uut.Add(test2);

            Assert.That(_uut.IsThereConflict(test1) == false);
        }

        [Test]
        public void AreAircraftsInConflict_AircraftNotOnList_ExpectedFalse()
        {
            FormattedData test1 = new FormattedData("Test1", 30000, 30000, 3000, DateTime.Today, "Nord", 0);
            _uut.Add(test1);

            FormattedData test2 = new FormattedData("Test2", 16000, 16000, 1800, DateTime.Today, "Nord", 0);
            _uut.Add(test2);

            FormattedData test3 = new FormattedData("Test3",10000,10000, 1000,DateTime.Today, "Nord",0);

            Assert.That(_uut.IsThereConflict(test3) == false);
        }

        [Test]
        public void AreAircraftsInConflict_OnlyOnePointOfConflictHorizontal_ExpectedFalse()
        {
            FormattedData test1 = new FormattedData("Test1", 30000, 30000, 3000, DateTime.Today, "Nord", 0);
            _uut.Add(test1);

            FormattedData test2 = new FormattedData("Test2", 16000, 16000, 1800, DateTime.Today, "Nord", 0);
            _uut.Add(test2);

            FormattedData test3 = new FormattedData("Test3", 15000, 10000, 1000, DateTime.Today, "Nord", 0);

            Assert.That(_uut.IsThereConflict(test3) == false);
        }

        [Test]
        public void AreAircraftsInConflict_OnlyOnePointOfConflictVertical_ExpectedFalse()
        {
            FormattedData test1 = new FormattedData("Test1", 30000, 30000, 3000, DateTime.Today, "Nord", 0);
            _uut.Add(test1);

            FormattedData test2 = new FormattedData("Test2", 16000, 16000, 1800, DateTime.Today, "Nord", 0);
            _uut.Add(test2);

            FormattedData test3 = new FormattedData("Test3", 24000, 10000, 1600, DateTime.Today, "Nord", 0);

            Assert.That(_uut.IsThereConflict(test3) == false);
        }
    }
}
