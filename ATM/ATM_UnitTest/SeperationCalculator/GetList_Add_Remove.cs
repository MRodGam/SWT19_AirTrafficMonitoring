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
    class GetList_Add_Remove
    {
        private ISeperationCalculator _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new SeperationCalculator();
        }


        [Test]
        public void Add_AddAircraftToList_ExpectedTrue()
        {
            FormattedData test1 = new FormattedData("test1",1,1,1,"1200","nord",10);
            _uut.Add(test1);

            FormattedData test2 = new FormattedData("test2", 2, 2, 2, "2200", "syd", 20);
            _uut.Add(test2);

            FormattedData test3 = new FormattedData("test3", 3, 3, 3, "3300", "øst", 30);
            _uut.Add(test3);

            Assert.AreEqual(_uut.GetAircraftList().Count,3);
        }

        [Test]
        public void Remove_RemoveAircraftToList_ExpectedTrue()
        {
            FormattedData test1 = new FormattedData("test1", 1, 1, 1, "1200", "nord", 10);
            _uut.Add(test1);

            FormattedData test2 = new FormattedData("test2", 2, 2, 2, "2200", "syd", 20);
            _uut.Add(test2);

            FormattedData test3 = new FormattedData("test3", 3, 3, 3, "3300", "øst", 30);
            _uut.Add(test2);

            _uut.Remove(test1);

            Assert.AreEqual(_uut.GetAircraftList().Count, 2);
        }

        [Test]
        public void Add_CompareAircraftInList_ExpectedTrue()
        {
            FormattedData test1 = new FormattedData("test1", 1, 1, 1, "1200", "nord", 10);
            _uut.Add(test1);
            FormattedData result = new FormattedData("0",0,0,0,"0","0",0);

            foreach (FormattedData test in _uut.GetAircraftList())
            {
                result = test;
            }

            Assert.AreEqual(test1.Tag,result.Tag);
            Assert.AreEqual(test1.XCoordinate, result.XCoordinate);
            Assert.AreEqual(test1.YCoordinate, result.YCoordinate);
            Assert.AreEqual(test1.Altitude, result.Altitude);
            Assert.AreEqual(test1.TimeStamp, result.TimeStamp);
            Assert.AreEqual(test1.CompassCourse, result.CompassCourse);
            Assert.AreEqual(test1.Speed, result.Speed);
        }
    }
}
