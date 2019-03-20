using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM;

namespace ATM_UnitTest.Log
{
    public class FakeLogWriter : IWriter
    {
        public bool WasWriterCalled = false;

        public void LogSeperation(List<Conflict> currentConflicts)
        {
            WasWriterCalled = true;
        }
    }
}

