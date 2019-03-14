using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface ILog
    {
        void LogSeperation(FormattedData conflict1, FormattedData conflict2);
    }
}
