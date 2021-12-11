using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CyberpunkQuestFactComparer
{
    public class QuestFact : IEquatable<QuestFact>
    {
        public long Hash { get; set; }
        public string FactName { get; set; }
        public int Value { get; set; }

        public bool Equals([AllowNull] QuestFact other)
        {
            return Hash == other.Hash && 
                   FactName == other.FactName && 
                   Value == other.Value;
        }

        public override bool Equals(object obj) => Equals(obj as QuestFact);
        public override int GetHashCode() => (Hash, FactName, Value).GetHashCode();
    }

    public class PartialQFEqualityComparer : IEqualityComparer<QuestFact>
    {
        public bool Equals([AllowNull] QuestFact x, [AllowNull] QuestFact y) => x.Hash == y.Hash && x.FactName == y.FactName && x.Value != y.Value;
        public int GetHashCode([DisallowNull] QuestFact obj) => (obj.Hash, obj.FactName).GetHashCode();
    }
}
