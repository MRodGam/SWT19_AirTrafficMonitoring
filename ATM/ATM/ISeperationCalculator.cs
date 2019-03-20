using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface ISeperationCalculator
    {
        bool IsAircraftInAirspace(FormattedData currentData);
        bool IsThereConflict(FormattedData currentData);
        FormattedData GetConflict();
        bool AreAircraftsInConflict(FormattedData currentData, FormattedData comparisonData);
        void Add(FormattedData currentData);
        void Remove(FormattedData oldData);
        List<FormattedData> GetAircraftList();
    }
}
