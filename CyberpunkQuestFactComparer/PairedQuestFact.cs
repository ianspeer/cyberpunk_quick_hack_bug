using System;
using System.Collections.Generic;
using System.Text;

namespace CyberpunkQuestFactComparer
{
    public class PairedQuestFact
    {
        public long Hash { get; set; }
        public string FactName { get; set; }
        public int BuggedValue { get; set; }
        public int SuccessfulValue { get; set;  }
    }
}
