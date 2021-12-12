using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CyberpunkQuestFactComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factsDirectory = args.Length > 0 ? args[0] : @"C:\Users\Ian\Documents\Code\quick_hack_breach_protocol_bug\facts";
            var successfulFacts = ParseFacts(factsDirectory, "SuccessfulSaveQuestFacts.txt");
            var buggedFacts = ParseFacts(factsDirectory, "BuggedSaveQuestFacts.txt");

            var identicalFacts = buggedFacts.Intersect(successfulFacts);
            Console.WriteLine($"Found {identicalFacts.Count()} identical facts.");
            ExportFacts(factsDirectory, "identicalfacts.json", identicalFacts);

            var factsWithDifferingValues = buggedFacts.Intersect(successfulFacts, new PartialQFEqualityComparer());
            var pairedFactsWithDifferingValues = GetFactsWithDifferingValues(factsWithDifferingValues, buggedFacts, successfulFacts);
            Console.WriteLine($"Found {factsWithDifferingValues.Count()} facts with differing values.");
            ExportFacts(factsDirectory, "factsWithDifferingValues.json", pairedFactsWithDifferingValues);

            var uniqueBugged = buggedFacts.Except(identicalFacts).Except(factsWithDifferingValues);
            Console.WriteLine($"{uniqueBugged.Count()} unique facts from bugged playthrough");
            ExportFacts(factsDirectory, "uniqueBuggedFacts.json", uniqueBugged);

            var uniqueSuccessful = successfulFacts.Except(identicalFacts).Except(factsWithDifferingValues);
            Console.WriteLine($"{uniqueSuccessful.Count()} unique facts from successful playthrough");
            ExportFacts(factsDirectory, "uniqueSuccessfulFacts.json", uniqueSuccessful);
        }

        private static void ExportFacts<T>(string directory, string fileName, IEnumerable<T> facts)
        {
            var fileLocation = Path.Combine(directory, fileName);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(facts, options);
            File.WriteAllText(fileLocation, jsonString);
            Console.WriteLine($"Exported {fileName} with {facts.Count()} elements.\n");
        }

        private static IEnumerable<PairedQuestFact> GetFactsWithDifferingValues(
            IEnumerable<QuestFact> differingValues,
            IEnumerable<QuestFact> buggedFacts,
            IEnumerable<QuestFact> successFacts)
        {

            return differingValues.Select(fact => new PairedQuestFact
            {
                FactName = fact.FactName,
                Hash = fact.Hash,
                BuggedValue = buggedFacts.FirstOrDefault(f => f.Hash == fact.Hash).Value,
                SuccessfulValue = successFacts.FirstOrDefault(s => s.Hash == fact.Hash).Value
            });
        }

        private static IEnumerable<QuestFact> ParseFacts(string directory, string fileName)
        {
            var fileLocation = Path.Combine(directory, fileName);
            var jsonText = File.ReadAllText(fileLocation);
            return JsonSerializer.Deserialize<List<QuestFact>>(jsonText);
        }
    }
}
