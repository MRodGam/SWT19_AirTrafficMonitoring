using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Log : ILog
    {
        public List<Conflict> currentConflicts { get; set; }
        private IWriter writer;

        private Conflict conflictToRemove;

        public Log(IWriter _writer)
        {
            currentConflicts = new List<Conflict>();
            writer = _writer;
        }

        public void Add(FormattedData conflict1, FormattedData conflict2)
        {
            currentConflicts.Add(new Conflict(conflict1,conflict2));
            writer.LogSeperation(GetConflictList());
        }

        public void Remove(FormattedData airplane)
        {
            foreach (Conflict conflict in GetConflictList())
            {
                if (conflict.tag1==airplane.Tag || conflict.tag2 == airplane.Tag)
                {
                    conflictToRemove = conflict;
                }
            }

            currentConflicts.Remove(conflictToRemove);
        }

        public List<Conflict> GetConflictList()
        {
            if (currentConflicts.Count<0)
            {
                return currentConflicts;
            }
            else
            {
                return null;
            }
        }
    }
}
