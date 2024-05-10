public class Scripture
{
    // Private fields to store reference and words of the scripture
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    // Constructor to initialize a scripture with a reference and text
    public Scripture(Reference reference, string text)
    {
        // Assigning the reference
        this._reference = reference;

        // Splitting the text into words and adding each word to the list of words
        string[] wordsArray = text.Split(' ');
        foreach (var word in wordsArray)
        {
            _words.Add(new Word(word));
        }
    }

    // Method to randomly hide a specified number of words in the scripture
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            // Generating a random index to select a word to hide
            int index = random.Next(_words.Count);
            _words[index].Hide(); // Hiding the selected word
        }
    }

    // Method to get the textual representation of the scripture
    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + ": "; // Constructing the display text with the scripture reference
        foreach (var word in _words)
        {
            displayText += word.GetDisplayText() + " "; // Adding each word's display text to the scripture display text
        }
        return displayText.Trim(); // Trimming any extra whitespace at the end
    }

    // Method to check if all words in the scripture are hidden
    public bool IsCompletelyHidden()
    {
        foreach (var word in _words)
        {
            if (!word.IsHidden()) // If any word is not hidden, return false
                return false;
        }
        return true; // If all words are hidden, return true
    }
}
