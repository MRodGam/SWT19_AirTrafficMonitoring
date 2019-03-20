using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Conflict
    {
        private FormattedData _conflict1;
        public string tag1;
        private FormattedData _conflict2;
        public string tag2;
        public DateTime timeStamp;

        public Conflict(FormattedData conflict1, FormattedData conflict2)
        {
            _conflict1 = conflict1;
            tag1 = _conflict1.Tag;
            _conflict2 = conflict2;
            tag2 = _conflict2.Tag;
            timeStamp = conflict1.TimeStamp;
        }
    }
}
