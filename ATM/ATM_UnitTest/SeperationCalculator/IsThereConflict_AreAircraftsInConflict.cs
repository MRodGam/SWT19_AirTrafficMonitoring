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
    class IsAircraftInConflict_AreAircraftsInConflict
    {
        private ISeperationCalculator _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new SeperationCalculator();
        }

        [Test]
        public void AreAircraftsInConflict_ManualInput_ExpectedTrue()
        {
            FormattedData test1 = new FormattedData("Test1",2000,2000,2000,0,"Nord",0);
            FormattedData test2 = new FormattedData("Test2",1600,1600,1800,0,"Nord",0);

            Assert.That(_uut.AreAircraftsInConflict(test1, test2) == true);
        }

        [Test]
        public void AreAircraftsInConflict_ManualInputTestOfAbsValue_ExpectedTrue()
        {
            FormattedData test1 = new FormattedData("Test2", 1600, 1600, 1800, 0, "Nord", 0);
            FormattedData test2 = new FormattedData("Test1", 2000, 2000, 2000, 0, "Nord", 0);

            Assert.That(_uut.AreAircraftsInConflict(test1, test2) == true);
        }

        [Test]
        public void AreAircraftsInConflict_ManualInput_ExpectedFalse()
        {
            FormattedData test1 = new FormattedData("Test1", 2000, 2000, 2000, 0, "Nord", 0);
            FormattedData test2 = new FormattedData("Test2", 2600, 2600, 2500, 0, "Nord", 0);

            Assert.That(_uut.AreAircraftsInConflict(test1, test2) == false);
        }

        [Test]
        public void AreAircraftsInConflict_ManualInputTestOfAbsValue_ExpectedFalse()
        {
            FormattedData test1 = new FormattedData("Test2", 2600, 2600, 2500, 0, "Nord", 0);
            FormattedData test2= new FormattedData("Test1", 2000, 2000, 2000, 0, "Nord", 0);

            Assert.That(_uut.AreAircraftsInConflict(test1, test2) == false);
        }

        [Test]
        public void IsThereConflict_ExpectedTrue()
        {
            FormattedData test1 = new FormattedData("Test1", 2000, 2000, 2000, 0, "Nord", 0);
            FormattedData test2 = new FormattedData("Test2", 1600, 1600, 1800, 0, "Nord", 0);

            Assert.That(_uut.AreAircraftsInConflict(test1, test2) == true);
        }


        [Test]
        public void AreAircraftsInConflict_InputThroughList_ExpectedTrue()
        {
            FormattedData test1 = new FormattedData("Test1", 2000, 2000, 2000, 0, "Nord", 0);
            _uut.Add(test1);

            FormattedData test2 = new FormattedData("Test2", 1600, 1600, 1800, 0, "Nord", 0);
            _uut.Add(test2);

            Assert.That(_uut.IsThereConflict(test1) == true);
        }

        [Test]
        public void AreAircraftsInConflict_InputThroughList_ExpectedFalse()
        {
            FormattedData test1 = new FormattedData("Test1", 3000, 3000, 3000, 0, "Nord", 0);
            _uut.Add(test1);

            FormattedData test2 = new FormattedData("Test2", 1600, 1600, 1800, 0, "Nord", 0);
            _uut.Add(test2);

            Assert.That(_uut.IsThereConflict(test1) == false);
        }

        [Test]
        public void AreAircraftsInConflict_AircraftNotOnList_ExpectedFalse()
        {
            FormattedData test1 = new FormattedData("Test1", 3000, 3000, 3000, 0, "Nord", 0);
            _uut.Add(test1);

            FormattedData test2 = new FormattedData("Test2", 1600, 1600, 1800, 0, "Nord", 0);
            _uut.Add(test2);

            FormattedData test3 = new FormattedData("Test3",1000,1000,1000,0,"Nord",0);

            Assert.That(_uut.IsThereConflict(test3) == false);
        }
    }
}
