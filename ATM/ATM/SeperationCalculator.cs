using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class SeperationCalculator : ISeperationCalculator
    {
        public List<FormattedData> AircraftsInAirspace;

        public SeperationCalculator()
        {
            AircraftsInAirspace = new List<FormattedData>();
        }

        public void Add(FormattedData currentData)
        {
            AircraftsInAirspace.Add(currentData);
        }

        public void Remove(FormattedData oldData)
        {
            AircraftsInAirspace.Remove(oldData);
        }

        public List<FormattedData> GetAircraftList()
        {
            return AircraftsInAirspace;
        }

        public bool EvaluateData(FormattedData formattedData)
        {
            bool result = false;

            foreach (FormattedData aircraft in GetAircraftList())
            {
                if (formattedData.Tag ==aircraft.Tag)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
