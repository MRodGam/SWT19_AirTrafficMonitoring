using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM;

namespace ATM_UnitTest
{
    class FakeLog : IWriter
    {
        public bool WasLogWritten = false;

        public void LogSeperation(List<Conflict> currentConflicts)
        {
            WasLogWritten = true;
        }
    }
}
