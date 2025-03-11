// Scripture.cs

using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureGame
{
    public class Scripture
    {
        public Reference Reference { get; set; }
        public List<Word> Words { get; set; }

        public Scripture(string reference, string text)
        {
            Reference = new Reference(reference);
            Words = text.Split(' ').Select(w => new Word(w)).ToList();
        }

        public void Display()
        {
            Console.WriteLine($"{Reference}: {string.Join(" ", Words)}");
        }

        public void HideRandomWord()
        {
            var availableWords = Words.Where(w => !w.Hidden).ToList();
            if (availableWords.Any())
            {
                var random = new Random();
                var wordToHide = availableWords[random.Next(availableWords.Count)];
                wordToHide.Hide();
            }
        }

        public bool AllWordsHidden()
        {
            return Words.All(w => w.Hidden);
        }
    }
}
