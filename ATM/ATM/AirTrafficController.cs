using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    public class AirTrafficController : IAirTrafficController
    {
        private IFormatter receiver;
        private ISeperationCalculator _seperationCalculator;
        private IPositionCalculator _positionCalculator;
        private ISpeedCalculator _speedCalculator;
        private IRender _render;

        public FormattedData CurrentData;
        public FormattedData oldData { get; private set; }

        public bool IsThereConflicts = false;

        public AirTrafficController(IFormatter receiver, ISeperationCalculator seperationCalculator, IRender render, IPositionCalculator positionCalculator, ISpeedCalculator speedCalculator)

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

        public void ReceiverOnFormattedDataReady(object sender, FormattedDataEventArgs e)
        {
            CurrentData = e.FormattedData;
            HandleNewData(e.FormattedData);
        }

        public void HandleNewData(FormattedData currentData)
        {
            if (_seperationCalculator.IsAircraftInAirspace(currentData) == true)
            {
                foreach (FormattedData aircraft in _seperationCalculator.GetAircraftList())
                {
                    if (currentData.Tag == aircraft.Tag)
                    {
                        oldData = aircraft;
                    }
                }

                currentData.Speed = _speedCalculator.CalculateSpeed(currentData, oldData);
                currentData.CompassCourse = _positionCalculator.CalculatePosition(currentData);
                _seperationCalculator.Remove(oldData);
                _seperationCalculator.Add(currentData);
                

                if (_seperationCalculator.IsThereConflict(currentData) == true)
                {
                    IsThereConflicts = true;

                    _render = new RenderWithSeperation();
                    _render.PrintData(_seperationCalculator.GetAircraftList());
                }
                else
                {
                    IsThereConflicts = false;

                    _render = new RenderData();
                    _render.PrintData(_seperationCalculator.GetAircraftList());
                }
            }
            else
            {
                _seperationCalculator.Add(currentData);
                _seperationCalculator.IsThereConflict(currentData);

                if (_seperationCalculator.IsThereConflict(currentData) == true)
                {
                    IsThereConflicts = true;
                    _render = new RenderWithSeperation();
                    _render.PrintData(_seperationCalculator.GetAircraftList());
                }
                else
                {
                    IsThereConflicts = false;
                    _render = new RenderData();
                    _render.PrintData(_seperationCalculator.GetAircraftList());
                }
            }
        }
    }
}
