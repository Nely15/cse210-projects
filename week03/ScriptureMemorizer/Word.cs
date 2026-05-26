public class Word
{
    private string _text;
    private bool _isHidden;
    private bool _showHint;

    public Word(string text)

    {

        _text = text;
        _isHidden = false;
        _showHint = false;
    
    }

    public void Hide()

    {

        _isHidden = true;
    
    }

    public bool IsHidden()

    {

        return _isHidden;
    
    }

    public void ShowHint()

    {

        _showHint = true;
    
    }

    public string GetDisplayText()

    {
    
        if (_isHidden)

        {
    
            if (_showHint)

            {
                string result = _text.Substring(0, 1);

                for (int i = 1; i < _text.Length; i++)

                {

                    result += "_";
    
                }

                return result;
    
            }

            string hiddenWord = "";

            for (int i = 0; i < _text.Length; i++)

            {

                hiddenWord += "_";
    
            }

            return hiddenWord;
    
        }

        return _text;

    }       

}