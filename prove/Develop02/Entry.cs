using System;
using System.Collections.Generic;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;
    private int _mood;

    public Entry(string date, string prompt, string response, int mood)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Mood: {_mood}/10");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine(_response);
        Console.WriteLine();
    }

    public string ToCsvString()
    {
        return $"{Escape(_date)},{Escape(_prompt)},{Escape(_response)},{_mood}";
    }

    public static Entry FromCsvString(string line)
    {
        List<string> fields = ParseCsvLine(line);
        return new Entry(fields[0], fields[1], fields[2], int.Parse(fields[3]));
    }

    private static string Escape(string text)
    {
        return "\"" + text.Replace("\"", "\"\"") + "\"";
    }

    private static List<string> ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        string current = "";
        bool inQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (inQuotes)
            {
                if (c == '"')
                {
                    if (i + 1 < line.Length && line[i + 1] == '"')
                    {
                        current += '"';
                        i++;
                    }
                    else
                    {
                        inQuotes = false;
                    }
                }
                else
                {
                    current += c;
                }
            }
            else
            {
                if (c == '"')
                {
                    inQuotes = true;
                }
                else if (c == ',')
                {
                    fields.Add(current);
                    current = "";
                }
                else
                {
                    current += c;
                }
            }
        }

        fields.Add(current);
        return fields;
    }
}