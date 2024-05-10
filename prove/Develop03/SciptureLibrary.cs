// Class representing a library of scriptures
public class ScriptureLibrary
{
    private List<Scripture> _scriptures = new List<Scripture>(); // List to store scriptures
    private Random _random = new Random(); // Random number generator for selecting random scriptures

    // Method to add a scripture to the library
    public void AddScripture(Scripture scripture)
    {
        _scriptures.Add(scripture); // Adding the scripture to the list
    }

    // Method to get a random scripture from the library
    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count); // Generating a random index within the range of available scriptures
        return _scriptures[index]; // Returning the scripture at the randomly selected index
    }
}
