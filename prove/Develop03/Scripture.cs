public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        string[] parts = text.Split(" ");
        foreach (string part in parts)
        {
            Word word = new Word(part);
            _words.Add(word);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        int wordCount = _words.Count();
        int unhiddenWordsCount = 0;

        foreach (Word word in _words)
        {
            if (word.IsHidden() == false)
            {
                unhiddenWordsCount += 1;
            }
        }

        if (numberToHide > unhiddenWordsCount)
        {
            numberToHide = unhiddenWordsCount;
        }

        for (int i = 0; i < numberToHide; i++)
        {
            bool repeat = true;
            while (repeat)
            {
                Random randomGenerator = new Random();
                int randomWordIndex = randomGenerator.Next(0, wordCount);
                if (_words[randomWordIndex].IsHidden() == false)
                {
                    _words[randomWordIndex].Hide();
                    repeat = false;
                }
            }
        }
    }

    public string GetDisplayText()
    {
        string displayText = $"{_reference.GetDisplayText()} ";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText();
            displayText += " ";
        }
        return displayText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (word.IsHidden() == false)
            {
                return false;
            }
        }
        return true;
    }
}