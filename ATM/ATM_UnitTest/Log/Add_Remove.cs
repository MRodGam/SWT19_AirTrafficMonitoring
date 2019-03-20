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
    class Add_Remove
    {
        private IWriter writer;
        private ILog _uut;

        [SetUp]
        public void SetUp()
        {
            writer = new LogWriter();
            _uut = new ATM.Log(writer);
        }

        [Test]
        public void Add_ManualAdditionOfAircraft_ExpectedTrue()
        {
            FormattedData test1 = new FormattedData("test1", 1, 1, 1, DateTime.Today, "nord", 10);
            FormattedData test2 = new FormattedData("test2", 2, 2, 2, DateTime.Today, "syd", 20);
            _uut.Add(test1,test2);

            FormattedData test3 = new FormattedData("test3", 3, 3, 3, DateTime.Today, "øst", 30);
            FormattedData test4 = new FormattedData("test4", 4, 4, 4, DateTime.Today, "vest", 40);
            _uut.Add(test3,test4);

            Assert.That(_uut.GetConflictList().Count ==2);
        }

        [Test]
        public void Remove_ManualAdditionOfAircraft_ExpectedTrue()
        {
            FormattedData test1 = new FormattedData("test1", 1, 1, 1, DateTime.Today, "nord", 10);
            FormattedData test2 = new FormattedData("test2", 2, 2, 2, DateTime.Today, "syd", 20);
            _uut.Add(test1, test2);

            FormattedData test3 = new FormattedData("test3", 3, 3, 3, DateTime.Today, "øst", 30);
            FormattedData test4 = new FormattedData("test4", 4, 4, 4, DateTime.Today, "vest", 40);
            _uut.Add(test3, test4);

            _uut.Remove(test1);

            Assert.That(_uut.GetConflictList().Count == 1);
        }
    }
}
