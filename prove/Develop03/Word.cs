public class Word
{
    // Private fields to store the text of the word and its hidden status
    private string _text;
    private bool _isHidden;

    // Constructor to initialize a word with text and set its hidden status to false
    public Word(string text)
    {
        // Assigning the text and setting the initial hidden status to false
        this._text = text;
        this._isHidden = false;
    }

    // Method to hide the word by setting its hidden status to true
    public void Hide()
    {
        _isHidden = true;
    }

    // Method to check if the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Method to get the display text of the word, either the actual text or a placeholder if it's hidden
    public string GetDisplayText()
    {
        return _isHidden ? "_____" : _text; // If the word is hidden, return a placeholder, otherwise return the actual text
    }
}
