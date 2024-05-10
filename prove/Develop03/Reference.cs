public class Reference
{
    // Private fields to store book name, chapter number, start verse, and end verse
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // Constructor for a single verse reference
    public Reference(string book, int chapter, int verse)
    {
        // Assigning values to the private fields
        this._book = book;
        this._chapter = chapter;
        this._startVerse = verse;
        this._endVerse = verse; // Since it's a single verse, start and end verse are the same
    }

    // Constructor for a range of verses
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        // Assigning values to the private fields
        this._book = book;
        this._chapter = chapter;
        this._startVerse = startVerse;
        this._endVerse = endVerse;
    }

    // Method to get the textual representation of the reference
    public string GetDisplayText()
    {
        // Constructing the display text in the format: "Book Chapter:StartVerse-EndVerse" or "Book Chapter:Verse" if it's a single verse
        return _book + " " + _chapter.ToString() + ":" + _startVerse.ToString() 
            + (_startVerse == _endVerse ? "" : "-" + _endVerse.ToString()); // If it's a range of verses, append the end verse
    }
}
