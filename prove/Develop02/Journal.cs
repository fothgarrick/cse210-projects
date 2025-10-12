using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAllEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo entries to display.");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileFormat());
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            Entry entry = Entry.FromFileFormat(line);
            if (entry != null)
            {
                _entries.Add(entry);
            }
        }
    }

    public List<Entry> SearchEntries(string keyword)
    {
        List<Entry> results = new List<Entry>();
        foreach (Entry entry in _entries)
        {
            if (entry.Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                entry.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                entry.Date.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                results.Add(entry);
            }
        }
        return results;
    }
}
