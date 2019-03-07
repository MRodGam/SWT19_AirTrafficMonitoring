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
            string data = "MAT218;1000;20000;10000;2019070312061010123”";
            FormattedData result =_uut.FormatData(data);
            Assert.AreEqual(result.Tag, "MAT218");
        }
    }
}
