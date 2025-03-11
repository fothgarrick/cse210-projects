// ScriptureLibrary.cs

using System;
using System.Collections.Generic;

namespace ScriptureGame
{
    public class ScriptureLibrary
    {
        private List<Scripture> scriptures;

        public ScriptureLibrary()
        {
            scriptures = new List<Scripture>
            {
                new Scripture("John 3:16", "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
                new Scripture("Proverbs 3:5-6", "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
                new Scripture("Philippians 4:13", "I can do all things through Christ which strengtheneth me."),
                new Scripture("Matthew 11:28", "Come unto me, all ye that labour and are heavy laden, and I will give you rest."),
                new Scripture("Romans 8:28", "And we know that all things work together for good to them that love God, to them who are the called according to his purpose."),
                new Scripture("Isaiah 41:10", "Fear thou not; for I am with thee: be not dismayed; for I am thy God: I will strengthen thee; yea, I will help thee; yea, I will uphold thee with the right hand of my righteousness.")
            };
        }

        public Scripture GetRandomScripture()
        {
            var random = new Random();
            return scriptures[random.Next(scriptures.Count)];
        }
    }
}
