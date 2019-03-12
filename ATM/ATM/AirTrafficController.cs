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

        public AirTrafficController(IFormatter receiver, ISeperationCalculator,IPositionCalculator,ISpeedCalculator,IRender)
        {
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;

            // Attach to the event of the real or the fake TDR
            this.receiver.FormattedDataReady += ReceiverOnFormattedDataReady;

        }

        private void ReceiverOnFormattedDataReady(object sender, FormattedDataEventArgs e)
        {
            CurrentData = e.FormattedData;
            HandleNewData(e.FormattedData);
        }

        private void HandleNewData(FormattedData currentData)
        {
            if (separationCalculator.EvaluateData(currentData) == true)
            {
                foreach (FormattedData aircraft in AircraftsInAirspace)
                {
                    if (currentData.Tag == aircraft.Tag)
                    {
                        OldData = aircraft;
                    }
                }

                currentData.Speed = speedCalculator.CalcuateSpeed(currentData, oldData);
                currentData.CompassCourse = courseCalculator.CalculateCourse(currentData, oldData);
                separationCalculator.Remove(OldData);
                separationCalculator.Add(currentData);


            }
            else
                separationCalculator.Add(currentData);
        }
    }
}
