using System;


public class Program
{
    public static void Main(string[] args)
    {
        // Create video instances
        var clip1 = new Video("Video Clip 1", "Author A", 300);
        var clip2 = new Video("Video Clip 2", "Author B", 150);
        var clip3 = new Video("Video Clip 3", "Author C", 500);

        // Add comments to video clip 1
        clip1.AddComment(new Comment("Name1", "Nice"));
        clip1.AddComment(new Comment("Name2", "Thanks"));
        clip1.AddComment(new Comment("Name3", "Very good"));

        // Add comments to video clip 2
        clip2.AddComment(new Comment("Name4", "great"));
        clip2.AddComment(new Comment("Name5", "Loved it"));
        clip2.AddComment(new Comment("Name6", "Well done"));

        // Add comments to video clip 3
        clip3.AddComment(new Comment("Name7", "Good job"));
        clip3.AddComment(new Comment("Name8", "Very nice"));
        clip3.AddComment(new Comment("Nmae9", "Not too bad"));

        // Store videos in a list
        var videos = new List<Video> { clip1, clip2, clip3 };

        // Display information for each video
        foreach (var video in videos)
        {
            video.DisplayInfo();
            Console.WriteLine(new string('-', 20)); // separate each object with 20 hyphens 
        }
    }
}
