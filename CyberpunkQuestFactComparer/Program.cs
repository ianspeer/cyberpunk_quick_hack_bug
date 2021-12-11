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

            var identicalFacts = buggedFacts.ToList().Intersect(successfulFacts.ToList());          
            Console.WriteLine($"Found {identicalFacts.Count()} identical facts.");
            ExportFacts(factsDirectory, "identicalfacts.json", identicalFacts);
            
            var factsWithDifferingValues = buggedFacts.Intersect(successfulFacts, new PartialQFEqualityComparer());
            Console.WriteLine($"Found {factsWithDifferingValues.Count()} facts with differing values.");
            ExportFacts(factsDirectory, "factsWithDifferingValues.json", factsWithDifferingValues);

            var uniqueBugged = buggedFacts.Except(identicalFacts).Except(factsWithDifferingValues);
            Console.WriteLine($"{uniqueBugged.Count()} unique facts from bugged playthrough");
            ExportFacts(factsDirectory, "uniqueBuggedFacts.json", uniqueBugged);

            var uniqueSuccessful = successfulFacts.Except(identicalFacts).Except(factsWithDifferingValues);
            Console.WriteLine($"{uniqueSuccessful.Count()} unique facts from successful playthrough");
            ExportFacts(factsDirectory, "uniqueSuccessfulFacts.json", uniqueSuccessful);
        }

        private static void ExportFacts(string directory, string fileName, IEnumerable<QuestFact> facts)
        {
            var fileLocation = Path.Combine(directory, fileName);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(facts, options);
            File.WriteAllText(fileLocation, jsonString);
            Console.WriteLine($"Exported {fileName}\n");
        }

        private static IEnumerable<QuestFact> ParseFacts(string directory, string fileName)
        {
            var fileLocation = Path.Combine(directory, fileName);
            var jsonText = File.ReadAllText(fileLocation);
            return JsonSerializer.Deserialize<List<QuestFact>>(jsonText);
        }
    }
}
