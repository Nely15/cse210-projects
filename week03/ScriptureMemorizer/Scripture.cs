using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] splitWords = text.Split(' ');

        foreach (string word in splitWords)

        {

            _words.Add(new Word(word));
        
        }

    }

    public void HideRandomWords(int numberToHide)

    {
        int hiddenCount = 0;

        while (hiddenCount < numberToHide)

        {

            int randomIndex = _random.Next(_words.Count);

            if (_words[randomIndex].IsHidden() == false)

            {
                _words[randomIndex].Hide();
                hiddenCount++;
            }

            if (AllWordsHidden())

            {

                break;

            }

        }

    }
    
    public bool AllWordsHidden()
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

    public void ShowHints()

    {

        foreach (Word word in _words)

        {

            if (word.IsHidden())

            {

                word.ShowHint();

            }

        }
        
    }
    
    public string GetProgress()

    {

        int hiddenWords = 0;

        foreach (Word word in _words)

        {
            if (word.IsHidden())

            {

                hiddenWords++;

            }

        }

        return $"Hidden words: {hiddenWords}/{_words.Count}";

    }

    public string GetDisplayText()

    {
        string displayText = "";

        displayText += _reference.GetDisplayText() + "\n";

        foreach (Word word in _words)

        {

            displayText += word.GetDisplayText() + " ";

        }

        return displayText;

    }
    
}