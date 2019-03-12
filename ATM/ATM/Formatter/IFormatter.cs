using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IFormatter
    {
        FormattedData currentData { get; set; }

        event EventHandler<FormattedDataEventArgs> FormattedDataReady;
        FormattedData FormatData(string data);
   
    }
}
