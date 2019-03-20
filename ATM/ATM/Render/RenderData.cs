using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class RenderData : IRender
    {
        public void PrintData(List<FormattedData> aircrafts, List<Conflict> conflicts)
        {
            Console.Clear();

            foreach (var aircraft in aircrafts)
            {
                string format = "Tag: " + aircraft.Tag + "\tPosition:  " + aircraft.XCoordinate + "," +
                                aircraft.YCoordinate + "\tAltitude: " +
                                aircraft.Altitude + "\tCourse: " + aircraft.CompassCourse + "\tSpeed: " +
                                aircraft.Speed +
                                " km/hour\tTime: " + aircraft.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff");
                Console.WriteLine(format);
            }
        }
    }
}
