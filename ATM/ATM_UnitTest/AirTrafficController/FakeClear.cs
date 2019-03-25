using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM;

namespace ATM_UnitTest
{
    class FakeClear : IClearConsole
    {
        public bool wasClearConsoleCalled = false;

        public void Clear()
        {
            wasClearConsoleCalled = true;
        }
    }
}
