﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface ISpeedCalculator
    {
        double CalculateSpeed(FormattedData currentData, FormattedData oldData);
        double CalculateHours(FormattedData currentData, FormattedData oldData);
    }
}
