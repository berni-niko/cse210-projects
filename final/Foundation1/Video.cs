public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    // Constructor
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    // AddComment method
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // GetCommentCount method
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    // DisplayInfo method
    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in _comments)
        {
            Console.WriteLine($"  - {comment.Name}: {comment.Text}");
        }
    }
}
