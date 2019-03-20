using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface ILog
    {
        void Add(FormattedData conflict1, FormattedData conflict2);
        void Remove(FormattedData conflict);
        List<Conflict> GetConflictList();
    }
}
