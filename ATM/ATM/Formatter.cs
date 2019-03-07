using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;


namespace ATM
{
    public class Formatter : IFormatter
    {
        private ITransponderReceiver receiver;
        public List<FormattedData> FormattedDataList; // Should be deleted, this is only for the initial print test
        public FormattedData currentData { get; set; }
        public event EventHandler<FormattedDataEventArgs> FormattedDataReady;
        private FormattedDataEventArgs args;


        // Using constructor injection for dependency/ies
        public Formatter(ITransponderReceiver receiver)
        {
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;

            // Attach to the event of the real or the fake TDR
            this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
        }

        private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e) 
        {
            // Just display data
            foreach (var data in e.TransponderData)
            {
                currentData = FormatData(data);
                //System.Console.WriteLine("Transponderdata Tag: {0} Placement: {1},{2} Altitude: {3}, Timestamp: {4}", FormatData(data).Tag, FormatData(data).XCoordinate, FormatData(data).YCoordinate, FormatData(data).Altitude, FormatData(data).TimeStamp);
                FormattedDataReady.Invoke(sender,new FormattedDataEventArgs(currentData));
            }
        }

        public FormattedData FormatData(string data)
        {
            string[] inputFields;
            inputFields = data.Split(';');
            currentData = new FormattedData(Convert.ToString(inputFields[0]), Convert.ToInt32(inputFields[1]), Convert.ToInt32(inputFields[2]), Convert.ToInt32(inputFields[3]), Convert.ToString(inputFields[4]),"",0);

            return currentData;
        }



    }
}
