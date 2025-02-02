using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    private Dictionary<string, List<string>> categorizedPrompts = new Dictionary<string, List<string>>
    {
        { "Reflection", new List<string> {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "If today had a theme or lesson, what would it be?"
        }},
        { "Gratitude", new List<string> {
            "How did I express gratitude today?",
            "What was a small moment of joy I experienced today?",
            "What is one thing I want to remember about today in the future?"
        }},
        { "Goals", new List<string> {
            "What did I learn today?",
            "If I had one thing I could do over today, what would it be?",
            "What is one thing I accomplished today that I’m proud of?"
        }}
    };

    private Random random = new Random();

    public void WriteNewEntry()
    {
        Console.WriteLine("Choose a category: Reflection, Gratitude, or Goals");
        string category = Console.ReadLine();

        if (!categorizedPrompts.ContainsKey(category))
        {
            Console.WriteLine("Invalid category. Defaulting to Reflection.");
            category = "Reflection";
        }

        string prompt = categorizedPrompts[category][random.Next(categorizedPrompts[category].Count)];
        
        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        
        entries.Add(new Entry(prompt, response));
        Console.WriteLine("Entry added successfully!\n");
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries found.\n");
            return;
        }
        
        foreach (var entry in entries)
        {
            Console.WriteLine(entry.ToString());
        }
        Console.WriteLine();
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        if (filename.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
        {
            Console.WriteLine("Invalid filename. Please try again.\n");
            return;
        }

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine(entry);
            }
        }
        Console.WriteLine($"Journal saved successfully to {filename}!\n");
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        entries.Clear();
        foreach (var line in File.ReadLines(filename))
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                entries.Add(new Entry(parts[1].Trim(), parts[2].Trim()) { Date = parts[0].Trim() });
            }
        }
        Console.WriteLine($"Journal loaded successfully from {filename}!\n");
    }
}
