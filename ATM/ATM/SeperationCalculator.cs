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
        public IPositionCalculator _positionCalculator;
        public ILog _log;

        //public SeperationCalculator(IPositionCalculator positionCalculator, ILog log)
        public SeperationCalculator()
        {
            AircraftsInAirspace = new List<FormattedData>();
            //_positionCalculator = positionCalculator;
            //_log = log;
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

        public bool IsAircraftInAirspace(FormattedData currentData)
        {
            bool result = false;

            foreach (FormattedData aircraft in GetAircraftList())
            {
                if (currentData.Tag ==aircraft.Tag)
                {
                    result = true;
                }
            }

            return result;
        }

        public bool IsThereConflict(FormattedData currentData)
        {
            bool result = false;

            foreach (FormattedData aircraft in GetAircraftList())
            {
                if (AreAircraftsInConflict(currentData,aircraft) ==true)
                {
                    result = true;
                    // _log.LogSeperation(currentData, aircraft);
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

        public bool AreAircraftsInConflict(FormattedData currentData, FormattedData comparisonData)
        {
            double distanceVectorX = Math.Abs(currentData.XCoordinate - comparisonData.XCoordinate);
            double distanceVectorY = Math.Abs(currentData.YCoordinate - comparisonData.YCoordinate);
            double distanceVectorDiagonal = Math.Abs(Math.Sqrt(Math.Pow(distanceVectorX,2)+ Math.Pow(distanceVectorY, 2)));
            double distanceVectorVertical = Math.Abs(currentData.Altitude - comparisonData.Altitude);

            bool result = false;

            if (distanceVectorX <= 5000  && distanceVectorVertical <= 300
                || distanceVectorY <=5000 && distanceVectorVertical <=300
                || distanceVectorDiagonal <=5000 && distanceVectorVertical <=300)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
