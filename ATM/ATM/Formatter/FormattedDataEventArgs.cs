using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class FormattedDataEventArgs :EventArgs
    {
        public FormattedData FormattedData;

        public FormattedDataEventArgs(FormattedData formattedData)
        {
            this.FormattedData = formattedData;
        }
    }
}
