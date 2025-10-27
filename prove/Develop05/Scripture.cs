public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] splitText = text.Split(' ');
        foreach (string word in splitText)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<int> visibleIndexes = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleIndexes.Add(i);
            }
        }

        if (visibleIndexes.Count == 0) return;

        int toHide = Math.Min(numberToHide, visibleIndexes.Count);

        for (int i = 0; i < toHide; i++)
        {
            int pick = _random.Next(visibleIndexes.Count);
            int index = visibleIndexes[pick];
            _words[index].Hide();
            visibleIndexes.RemoveAt(pick);
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = "";
        foreach (Word word in _words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }
        return $"{_reference.GetDisplayText()}\n{scriptureText.Trim()}";
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden()) return false;
        }
        return true;
    }

    public int VisibleWordCount()
    {
        int count = 0;
        foreach (var w in _words)
        {
            if (!w.IsHidden()) count++;
        }
        return count;
    }
}
