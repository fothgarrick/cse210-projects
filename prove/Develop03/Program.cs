// Program.cs

using System;

namespace ScriptureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Start();
        }

        public void Start()
        {
            var scriptureLibrary = new ScriptureLibrary();
            var scripture = scriptureLibrary.GetRandomScripture();  // Select a random scripture from the library

            while (true)
            {
                Console.Clear();  // Clear the console screen
                scripture.Display();  // Display the current scripture

                Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
                string userInput = Console.ReadLine().Trim().ToLower();

                if (userInput == "quit")
                {
                    break;
                }

                scripture.HideRandomWord();  // Hide a random word

                if (scripture.AllWordsHidden())
                {
                    Console.Clear();
                    scripture.Display();
                    Console.WriteLine("\nAll words are hidden. The program will now exit.");
                    break;
                }
            }
        }
    }
}
