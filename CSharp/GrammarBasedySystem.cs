using System;
using System.Collections.Generic;

Random rand = new Random();
string currentQuest = "";

List<string> GenerateQuestOptions()
{
    var tasks = new List<string> { "gathering herbs", "defeating the dragon", "exploring the ancient ruins" };
    currentQuest = tasks[rand.Next(tasks.Count)];
    return new List<string>
    {
        $"I need help with {currentQuest}.",
        $"Could you assist me with {currentQuest}?",
        $"{currentQuest} has been troubling me."
    };
}

List<string> GenerateFarewellOptions(string quest)
{
    var baseFarewells = new List<string> { "Farewell, <name>.", "Goodbye, and good luck.", "See you later, <name>." };
    if (quest.Contains("dragon"))
    {
        baseFarewells.Add("Take care, and watch out for the dragon's fire!");
    }
    else if (quest.Contains("ruins"))
    {
        baseFarewells.Add("Be cautious in the ruins; who knows what lurks in the shadows.");
    }
    else
    {
        baseFarewells.Add("May your journey be fruitful, <name>.");
    }
    return baseFarewells;
}

var rules = new Dictionary<string, Func<List<string>>>()
{
    ["<greet>"] = () => new List<string> { "Hello, traveler!", "Greetings, <name>.", "How can I assist you today, <name>?" },
    ["<quest>"] = GenerateQuestOptions,
    ["<farewell>"] = () => GenerateFarewellOptions(currentQuest),
    ["<name>"] = () => new List<string> { "hero", "adventurer", "friend" },
    ["<task>"] = () => new List<string> { "gathering herbs", "defeating the dragon", "exploring the ancient ruins" }
};

string GenerateDialogue(string key)
{
    if (!rules.TryGetValue(key, out var generator))
    {
        return key; // No rule for this key, return the key itself
    }

    var options = generator.Invoke();
    var option = options[rand.Next(options.Count)];

    // Find and replace sub-rules
    foreach (var rule in rules.Keys)
    {
        if (option.Contains(rule))
        {
            option = option.Replace(rule, GenerateDialogue(rule));
        }
    }

    return option;
}

Console.WriteLine(GenerateDialogue("<greet>"));
Console.WriteLine(GenerateDialogue("<quest>"));
Console.WriteLine(GenerateDialogue("<farewell>"));
