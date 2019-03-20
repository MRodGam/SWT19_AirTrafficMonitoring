using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class LogWriter : IWriter
    {
        private System.IO.StreamWriter file;

        public LogWriter()
        {
        }

        public void LogSeperation(List<Conflict> currentConflicts)
        {
            using (StreamWriter w = File.AppendText(@"Conflicts.txt"))
            {
                foreach (var conflict in currentConflicts)
                {
                    string formattedConflict = "Conflict occured at " + conflict.timeStamp + " between " + conflict.tag1 +
                                               " and " + conflict.tag2;

                    w.Write(formattedConflict);
                }
            }
        }
    }
}
