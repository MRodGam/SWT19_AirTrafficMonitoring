using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class FormattedData
    {
        public string Tag { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int Altitude { get; set; }
        public string TimeStamp { get; set; }
        public string CompassCourse { get; set; }
        public double Speed { get; set; }

        public FormattedData(string tag, int xcoordinate, int ycoordinate, int altitude, string timestamp, string compasscourse, double speed)
        {
            Tag = tag;
            XCoordinate = xcoordinate;
            YCoordinate = ycoordinate;
            Altitude = altitude;
            TimeStamp = DateTime.Now.ToString(timestamp);
            CompassCourse = compasscourse;
            Speed = speed;
        }
    }
}
