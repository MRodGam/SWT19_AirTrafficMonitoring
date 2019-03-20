using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Log : ILog
    {
        private System.IO.StreamWriter file;
        private List<Conflict> currentConflicts;
        public Log()
        {
            file = new System.IO.StreamWriter(@"Conflicts.txt");
            currentConflicts = new List<Conflict>();
        }

        public void Add(FormattedData conflict1, FormattedData conflict2)
        {
            currentConflicts.Add(new Conflict(conflict1,conflict2));
            LogSeperation(conflict1, conflict2);
        }

        public void Remove(FormattedData airplane)
        {
            foreach (var conflict in currentConflicts)
            {
                if (conflict.tag1==airplane.Tag || conflict.tag2 == airplane.Tag)
                {
                    currentConflicts.Remove(conflict);
                }
            }
        }

        public void LogSeperation(FormattedData conflict1, FormattedData conflict2)
        {
            foreach (var conflict in currentConflicts)
            {
                string formattedConflict = "Conflict occured at " + conflict.timeStamp + " between " + conflict.tag1 +
                                           " and " + conflict.tag2;

                file.Write(formattedConflict);
            }

            file.Close();
        }
    }
}
