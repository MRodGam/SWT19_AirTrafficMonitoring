using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransponderReceiver;
using ATM;

namespace ATMApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using the real transponder data receiver
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();

            // Dependency injection with the real TDR
            var formatter = new Formatter(receiver);
            var seperation = new SeperationCalculator();
            var speed = new SpeedCalculator();
            var position = new PositionCalculator();
            var render = new RenderWithSeperation();
            var writer = new LogWriter();
            var log = new Log(writer);
            //var system = new AirTrafficController(formatter,seperation,position,speed,render);
            var system = new AirTrafficController(formatter,seperation);

            // Let the real TDR execute in the background
            while (true)
                Thread.Sleep(1000);
        }
    }
}
