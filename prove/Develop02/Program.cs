using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    private static Journal _journal = new Journal();
    private static List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What made me smile today?",
        "What did I learn today that I didn't know before?"
    };

    public static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n--- Journal Menu ---");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Search entries");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option (1-6): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    _journal.DisplayAllEntries();
                    break;
                case "3":
                    SaveJournal();
                    break;
                case "4":
                    LoadJournal();
                    break;
                case "5":
                    SearchEntries();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void WriteNewEntry()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd");
        Entry newEntry = new Entry(date, prompt, response);
        _journal.AddEntry(newEntry);

        Console.WriteLine("Entry saved successfully.");
    }

    private static string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private static void SaveJournal()
    {
        Console.Write("Enter filename to save (e.g., journal.txt): ");
        string fileName = Console.ReadLine();
        _journal.SaveToFile(fileName);
        Console.WriteLine($"Journal saved to {fileName}");
    }

    private static void LoadJournal()
    {
        Console.Write("Enter filename to load (e.g., journal.txt): ");
        string fileName = Console.ReadLine();
        _journal.LoadFromFile(fileName);
        Console.WriteLine("Journal loaded successfully.");
    }

    private static void SearchEntries()
    {
        Console.Write("Enter a keyword to search for: ");
        string keyword = Console.ReadLine();
        List<Entry> results = _journal.SearchEntries(keyword);

        if (results.Count == 0)
        {
            Console.WriteLine("No entries found matching your search.");
        }
        else
        {
            Console.WriteLine($"\nFound {results.Count} matching entries:");
            foreach (Entry entry in results)
            {
                entry.Display();
            }
        }
    }
}
