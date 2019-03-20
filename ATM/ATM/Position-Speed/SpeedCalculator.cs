using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class SpeedCalculator : ISpeedCalculator
    {
        public double CalculateSpeed(FormattedData currentData, FormattedData oldData)
        {
            // Speed gets calculated by looking at the distance between two points in space 
            double distance = Math.Abs(Math.Sqrt(Math.Pow((currentData.XCoordinate - oldData.XCoordinate), 2) +
                                        Math.Pow((currentData.YCoordinate - oldData.YCoordinate), 2) +
                                        Math.Pow((currentData.Altitude - oldData.Altitude), 2)));
            double time = CalculateHours(currentData, oldData);

            return distance / time;
        }

        public double CalculateHours(FormattedData currentData, FormattedData oldData)
        {
            
            TimeSpan difference = DateTime.Parse(currentData.TimeStamp) - DateTime.Parse(oldData.TimeStamp);
            double dif = Convert.ToDouble(difference);

            return dif;

        }
    }
}
