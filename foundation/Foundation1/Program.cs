using System;
using System.Collections.Generic;

// This is a comment class to store commenter's name and text
public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    // Initialize Comment objects
    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

// Video class to track video details and comments by users
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments { get; set; }

    // Initialize Video objects using the constructors
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    // Adding comments to the video here
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    // Return the number of comments for the video
    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    // Display video information and comments
    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        
        foreach (var comment in Comments)
        {
            Console.WriteLine($"Comment by {comment.CommenterName}: {comment.Text}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        // Create videos
        var video1 = new Video("How to read the scriptures", "Charlie", 120);
        var video2 = new Video("My Book of Mormon Experience", "Emrys", 180);
        
        // Add comments to the videos
        video1.AddComment(new Comment("Ukoh", "Great video!"));
        video1.AddComment(new Comment("UtahViewer", "Interesting content."));
        video2.AddComment(new Comment("BYU456", "Well done."));
        
        // Display video details
        var videos = new List<Video> { video1, video2 };
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}