using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    public class AirTrafficController
    {
        private IFormatter receiver;
        public FormattedData CurrentData { get; private set; }
        public FormattedData OldData { get; private set; }
        public List<FormattedData> AircraftsInAirspace;


        public AirTrafficController(IFormatter receiver)
        {
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;

            // Attach to the event of the real or the fake TDR
            this.receiver.FormattedDataReady += ReceiverOnFormattedDataReady;

            AircraftsInAirspace = new List<FormattedData>();
        }

        private void ReceiverOnFormattedDataReady(object sender, FormattedDataEventArgs e)
        {
            CurrentData = e.FormattedData;
            System.Console.WriteLine("Transponderdata Tag: {0} Placement: {1},{2} Altitude: {3}, Timestamp: {4}", CurrentData.Tag, CurrentData.XCoordinate,
                CurrentData.YCoordinate, CurrentData.Altitude, CurrentData.TimeStamp);
            //HandleNewData(e.FormattedData);
        }

        //private void HandleNewData(FormattedData currentData)
        //{
        //    if (separationCalculator.IsAircraftInAirspace(currentData) == true)
        //    {
        //        foreach (FormattedData aircraft in AircraftsInAirspace)
        //        {
        //            if (currentData.Tag == aircraft.Tag)
        //            {
        //                OldData = aircraft;
        //            }
        //        }

        //        currentData.Speed = speedCalculator.CalcuateSpeed(currentData.XCoordinate, currentData.YCoordinate, OldData.XCoordinate, OldData.YCoordinate);
        //        currentData.CompassCourse = courseCalculator.CalculateCourse(currentData.XCoordinate, currentData.YCoordinate, OldData.XCoordinate, OldData.YCoordinate);
        //        separationCalculator.Remove(OldData);
        //        separationCalculator.Add(currentData);

        //    }
        //    else
        //        separationCalculator.Add(currentData);
        //}
    }
}
