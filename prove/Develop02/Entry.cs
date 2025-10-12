using System;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;

    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public string Date => _date;
    public string Prompt => _prompt;
    public string Response => _response;

    public void Display()
    {
        Console.WriteLine("------------------------------");
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
    }

    public string ToFileFormat()
    {
        // Using | as a separator
        return $"{_date}|{_prompt}|{_response}";
    }

    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length < 3)
            return null;

        string date = parts[0];
        string prompt = parts[1];
        string response = parts[2];
        return new Entry(date, prompt, response);
    }
}
