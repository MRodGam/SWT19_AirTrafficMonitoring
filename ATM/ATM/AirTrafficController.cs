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
        private ISeperationCalculator _seperationCalculator;
        private IPositionCalculator _positionCalculator;
        private ISpeedCalculator _speedCalculator;
        private IRender _render;

        public FormattedData CurrentData { get; private set; }
        public FormattedData oldData { get; private set; }

        public AirTrafficController(IFormatter receiver, ISeperationCalculator seperationCalculator,IPositionCalculator positionCalculator,ISpeedCalculator speedCalculator,IRender render)
        {
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;

            // Attach to the event of the real or the fake TDR
            this.receiver.FormattedDataReady += ReceiverOnFormattedDataReady;

            _seperationCalculator = seperationCalculator;
            _positionCalculator = positionCalculator;
            _speedCalculator = speedCalculator;
            _render = render;
        }

        private void ReceiverOnFormattedDataReady(object sender, FormattedDataEventArgs e)
        {
            CurrentData = e.FormattedData;
            HandleNewData(e.FormattedData);
        }

        private void HandleNewData(FormattedData currentData)
        {
            if (_seperationCalculator.EvaluateData(currentData) == true)
            {
                foreach (FormattedData aircraft in _seperationCalculator.GetAircraftList())
                {
                    if (currentData.Tag == aircraft.Tag)
                    {
                        oldData = aircraft;
                    }
                }

                currentData.Speed = _speedCalculator.CalcuateSpeed(currentData, oldData);
                currentData.CompassCourse = _positionCalculator.CalculateCourse(currentData, oldData);
                _seperationCalculator.Remove(oldData);
                _seperationCalculator.Add(currentData);


            }
            else
                _seperationCalculator.Add(currentData);
        }
    }
}
