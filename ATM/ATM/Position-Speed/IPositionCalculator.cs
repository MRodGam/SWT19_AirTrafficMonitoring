using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IPositionCalculator
    {
        string CalculatePosition(FormattedData currentData, FormattedData oldData);
    }
}
