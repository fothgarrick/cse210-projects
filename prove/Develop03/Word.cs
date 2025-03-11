// Word.cs

using System;

namespace ScriptureGame
{
    public class Word
    {
        public string Text { get; set; }
        public bool Hidden { get; set; }

        public Word(string text)
        {
            Text = text;
            Hidden = false;
        }

        public void Hide()
        {
            Hidden = true;
        }

        public override string ToString()
        {
            return Hidden ? "_" : Text;
        }
    }
}
