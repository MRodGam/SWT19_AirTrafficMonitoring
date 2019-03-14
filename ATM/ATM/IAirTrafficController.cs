using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IAirTrafficController
    {
        void ReceiverOnFormattedDataReady(object sender, FormattedDataEventArgs e);
        void HandleNewData(FormattedData currentData);


    }
}
