using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var reference = new Reference("Proverbs", 3, 5, 6);
        var scriptureText = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";
        var scripture = new Scripture(reference, scriptureText);
        var memorizer = new ScriptureMemorizer(scripture);
        memorizer.Run();
    }
}

public class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int VerseStart { get; private set; }
    public int? VerseEnd { get; private set; }

    public Reference(string book, int chapter, int verseStart, int verseEnd = 0)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd == 0 ? (int?)null : verseEnd;
    }

    public string GetDisplayText()
    {
        if (VerseEnd.HasValue)
            return $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
        else
            return $"{Book} {Chapter}:{VerseStart}";
    }
}

public class Word
{
    public string Text { get; private set; }
    private bool _hidden;

    public Word(string text)
    {
        Text = text;
        _hidden = false;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public string GetDisplayText()
    {
        return _hidden ? "_____" : Text;
    }
}

public class Scripture
{
    public Reference Reference { get; private set; }
    public List<Word> Words { get; private set; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public string GetDisplayText()
    {
        var wordsText = string.Join(" ", Words.Select(word => word.GetDisplayText()));
        return $"{Reference.GetDisplayText()}\n{wordsText}";
    }

    public void HideRandomWords(int count = 3)
    {
        var random = new Random();
        var visibleWords = Words.Where(word => !word.IsHidden()).ToList();

        for (int i = 0; i < count; i++)
        {
            if (visibleWords.Any())
            {
                var randomWord = visibleWords[random.Next(visibleWords.Count)];
                randomWord.Hide();
                visibleWords.Remove(randomWord);
            }
        }
    }
}

public class ScriptureMemorizer
{
    public Scripture Scripture { get; private set; }

    public ScriptureMemorizer(Scripture scripture)
    {
        Scripture = scripture;
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(Scripture.GetDisplayText());

            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            var input = Console.ReadLine().ToLower();
            if (input == "quit")
                break;

            Scripture.HideRandomWords();
            if (Scripture.Words.All(word => word.IsHidden()))
                break;
        }

        Console.WriteLine("All words are hidden. Memorization session is over.");
    }
}
