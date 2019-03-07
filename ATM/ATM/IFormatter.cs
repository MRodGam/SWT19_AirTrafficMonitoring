using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IFormatter
    {
        event EventHandler<FormattedDataEventArgs> FormattedDataReady;
    }
}
