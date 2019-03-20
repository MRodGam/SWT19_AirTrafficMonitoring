using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using ATM;
using TransponderReceiver;

namespace ATM_UnitTest
{
    [TestFixture]
    class HandleNewData
    {
        private ITransponderReceiver _fakeTransponderReceiver;
        private IFormatter _formatter;
        private ISeperationCalculator _seperationCalculator;
        private IAirTrafficController _uut;

        [SetUp]
        public void SetUp()
        {
            // Make a fake Transponder Data Receiver
            _fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();

            _formatter = new Formatter(_fakeTransponderReceiver);
            _seperationCalculator = new SeperationCalculator();
            _uut = new AirTrafficController(_formatter, _seperationCalculator);
        }

        [Test]
        public void TestReception_InputThroughTransponderOneAircraft_ExpectedTrue()
        {
            // Setup test data
            FormattedData result = null;
            List<string>
                testData =
                    new List<string>(); // Creates list with manual value that is send through trigger from TransponderData to Formatter.
            string value = "ATR423;39045;12932;14000;20151006213456789";

            testData.Add(value);
            _formatter.FormattedDataReady += (o, e) =>
            {
                result = e.FormattedData;
            }; //Simulates formatted data ready event

            // Act: Trigger the fake object to execute event invocation
            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            Assert.That(_seperationCalculator.GetAircraftList().Count == 1);
        }

        [Test]
        public void TestReception_InputThroughTransponderThreeAircraft_ExpectedTrue()
        {
            // Setup test data
            FormattedData result = null;
            List<string>
                testData =
                    new List<string>(); // Creates list with manual value that is send through trigger from TransponderData to Formatter.
            string test1 = "ATR423;39045;12932;14000;20151006213456789";
            testData.Add(test1);

            string test2 = "PPL120;29045;22932;24000;20151006213456888";
            testData.Add(test2);

            string test3 = "QQL123;19045;12932;34000;20151006213999999";
            testData.Add(test3);

            _formatter.FormattedDataReady += (o, e) =>
            {
                result = e.FormattedData;
            }; //Simulates formatted data ready event

            // Act: Trigger the fake object to execute event invocation
            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            Assert.That(_seperationCalculator.GetAircraftList().Count == 3);
        }

        [Test]
        public void TestReception_InputThroughTransponderSameAircraftNewPosition_ExpectedTrue()
        {
            // Setup test data
            FormattedData result = null;
            List<string>
                testData =
                    new List<string>(); // Creates list with manual value that is send through trigger from TransponderData to Formatter.
            string test1 = "ATR423;39045;12932;14000;20151006213456789";
            testData.Add(test1);

            string test2 = "PPL120;29045;22932;24000;20151006213456888";
            testData.Add(test2);

            string test1_new = "ATR423;19045;12932;34000;20151006213999999";
            testData.Add(test1_new);

            _formatter.FormattedDataReady += (o, e) =>
            {
                result = e.FormattedData;
            }; //Simulates formatted data ready event

            // Act: Trigger the fake object to execute event invocation
            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            Assert.That(_seperationCalculator.GetAircraftList().Count == 2);
        }

        [Test]
        public void TestReception_InputThroughTransponderAirplaneInConflict_ExpectedTrue()
        {
            // Setup test data
            FormattedData result = null;
            List<string>
                testData =
                    new List<string>(); // Creates list with manual value that is send through trigger from TransponderData to Formatter.
            string test1 = "ATR423;39045;12932;14000;20151006213456789";
            testData.Add(test1);

            string test2 = "PPL120;29045;22932;24000;20151006213456888";
            testData.Add(test2);

            string test3 = "QQL123; 35045; 137932; 15800; 20151006213999999";
            testData.Add(test3);

            _formatter.FormattedDataReady += (o, e) =>
            {
                result = e.FormattedData;
            }; //Simulates formatted data ready event

            // Act: Trigger the fake object to execute event invocation
            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            FormattedData test3_formatted = _formatter.FormatData(test3);

            Assert.That(_seperationCalculator.IsThereConflict(test3_formatted)==true);
        }

        [Test]
        public void TestReception_InputThroughTransponderAirplaneInConflictHorizontal_ExpectedFalse()
        {
            // Setup test data
            FormattedData result = null;
            List<string>
                testData =
                    new List<string>(); // Creates list with manual value that is send through trigger from TransponderData to Formatter.
            string test1 = "ATR423;50000;50000;50000;20151006213456789";
            testData.Add(test1);

            string test2 = "PPL120;10000;10000;24000;20151006213456888";
            testData.Add(test2);


            _formatter.FormattedDataReady += (o, e) =>
            {
                result = e.FormattedData;
            }; //Simulates formatted data ready event

            // Act: Trigger the fake object to execute event invocation
            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            string test3 = "QQL123;13000; 30000; 30800; 20151006213999999";
            FormattedData test3Formatted = _formatter.FormatData(test3);

            Assert.That(_seperationCalculator.IsThereConflict(test3Formatted) == false);
        }

        [Test]
        public void TestReception_InputThroughTransponderAirplaneInConflictVertical_ExpectedFalse()
        {
            // Setup test data
            FormattedData result = null;
            List<string>
                testData =
                    new List<string>(); // Creates list with manual value that is send through trigger from TransponderData to Formatter.
            string test1 = "ATR423;50000;50000;50000;20151006213456789";
            testData.Add(test1);

            string test2 = "PPL120;10000;10000;24000;20151006213456888";
            testData.Add(test2);


            _formatter.FormattedDataReady += (o, e) =>
            {
                result = e.FormattedData;
            }; //Simulates formatted data ready event

            // Act: Trigger the fake object to execute event invocation
            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            string test3 = "QQL123;20000; 30000; 24300; 20151006213999999";
            FormattedData test3Formatted = _formatter.FormatData(test3);

            Assert.That(_seperationCalculator.IsThereConflict(test3Formatted) == false);
        }

        [Test]
        public void TestReception_InputThroughTransponderSameAirplaneDifferentPositions_ExpectedFalse()
        {
            // Setup test data
            FormattedData result = null;
            List<string>
                testData =
                    new List<string>(); // Creates list with manual value that is send through trigger from TransponderData to Formatter.
            string test1 = "ATR423;50000;50000;50000;20151006213456789";
            testData.Add(test1);

            string test2 = "PPL120;10000;10000;24000;20151006213456888";
            testData.Add(test2);


            _formatter.FormattedDataReady += (o, e) =>
            {
                result = e.FormattedData;
            }; //Simulates formatted data ready event

            // Act: Trigger the fake object to execute event invocation
            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            string test3 = "ATR423;51000; 53000; 50100; 20151006213999999";
            FormattedData test3Formatted = _formatter.FormatData(test3);

            Assert.That(_seperationCalculator.IsThereConflict(test3Formatted) == false);
        }



    }
}