using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class PositionCalculator : IPositionCalculator
    {
        private double currentDegrees;
        private string currentCourse;
        private double findA;

        public string CalculatePosition(FormattedData currentData) //angiver en kurs i grader
        {
            // tanA=x-coordinat/y-coordinat 
            findA = currentData.YCoordinate/currentData.XCoordinate;
            currentDegrees = Math.Tan(findA)*57.29578; //omregner fra radianer til grader
            if (currentDegrees <= -1 && currentDegrees >= -180)
            {
                currentDegrees = currentDegrees + 360;
            }
            return WriteCurrentPosition(currentDegrees);
        }

        public string WriteCurrentPosition(double currentDegrees)
        {
            // Når koorkdinatet er mellem 315 og 45 grader skal den udskrive Nord. 
            if (currentDegrees > 315 && currentDegrees <= 360 ||currentDegrees > 0 && currentDegrees <= 45)
            {
                currentCourse = "Nord";
            }

            // Når koorkdinatet er mellem 45 og 135 grader skal den udskrive Øst.
            if (currentDegrees > 45 && currentDegrees <= 135)
            {
                currentCourse = "Øst";
            }

            // Når koorkdinatet er mellem 135 og 225 grader skal den udskrive Syd.
            else if (currentDegrees > 135 && currentDegrees <= 225)
            {
                currentCourse = "Syd";
            }

            // Når koorkdinatet er mellem 225 og 315 grader skal den udskrive Vest.
            else if (currentDegrees > 225 && currentDegrees <= 315)
            {
                currentCourse = "Vest";
            }

            return currentCourse;
        }

    }
}
