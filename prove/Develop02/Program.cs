// EXCEEDING REQUIREMENTS:
// 1. Added a mood rating (1-10) to every entry. It is validated when entered,
//    shown when the journal is displayed, and saved and loaded with the entry.
// 2. Journal files are saved and loaded as real CSV files that open correctly in Excel.
//    Quotes and commas inside responses are escaped, and the file includes a header row.

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                int mood = 0;
                while (mood < 1 || mood > 10)
                {
                    Console.Write("How would you rate your day (1-10)? ");
                    int.TryParse(Console.ReadLine(), out mood);
                }

                string date = DateTime.Now.ToShortDateString();
                journal.AddEntry(new Entry(date, prompt, response, mood));
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "5")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Please choose a number from 1 to 5.");
            }
        }
    }
}