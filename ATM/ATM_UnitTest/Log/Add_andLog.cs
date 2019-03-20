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

namespace ATM_UnitTest.Log
{
    [TestFixture]
    class Add_andLog
    {

        private FakeLogWriter writer;
        private ILog _uut;

        [SetUp]
        public void SetUp()
        {
            writer = new FakeLogWriter();
            _uut = new ATM.Log(writer);
        }

        [Test]
        public void Add_ManualAdditionOfAircraft_ExpectedTrue()
        {
            FormattedData test1 = new FormattedData("test1", 1, 1, 1, DateTime.Today, "nord", 10);
            FormattedData test2 = new FormattedData("test2", 2, 2, 2, DateTime.Today, "syd", 20);
            _uut.Add(test1, test2);

            Assert.That(_uut.GetConflictList().Count == 1);
            Assert.That(writer.WasWriterCalled== true);
        }
    }
}
