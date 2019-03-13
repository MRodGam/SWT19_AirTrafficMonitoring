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
    public class FormatData
    {
        private ITransponderReceiver _fakeTransponderReceiver;
        private IFormatter _uut;

        [SetUp]
        public void SetUp()
        {
            // Make a fake Transponder Data Receiver
            _fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
            // Inject the fake TDR
            _uut = new Formatter(_fakeTransponderReceiver);
        }

        [Test]
        public void FormatData_Tag_ManualInputTest_ExpectedTrue()
        {
            string data = "MAT218;1000;20000;10000;2019070312061010123";
            FormattedData result =_uut.FormatData(data);
            Assert.AreEqual(result.Tag, "MAT218");
        }

        [Test]
        public void TestReception_InputThroughTransponder_ExpectedTrue()
        {
            // Setup test data
            FormattedData result =null;
            List<string> testData = new List<string>(); // Creates list with manual value that is send through trigger from TransponderData to Formatter.
            string value = "ATR423;39045;12932;14000;20151006213456789";

            testData.Add(value);
            _uut.FormattedDataReady += (o, e) => { result = e.FormattedData; }; //Simulates formatted data ready event

            // Act: Trigger the fake object to execute event invocation
            _fakeTransponderReceiver.TransponderDataReady
               += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            // Assert that result and expected are equal
            Assert.AreEqual(result.Tag, "ATR423");
            Assert.AreEqual(result.XCoordinate, 39045);
            Assert.AreEqual(result.YCoordinate, 12932);
            Assert.AreEqual(result.Altitude, 14000);
            Assert.AreEqual(result.TimeStamp, 20151006213456789);
            Assert.AreEqual(result.CompassCourse,"");
            Assert.AreEqual(result.Speed,0);
        }
    }
}

