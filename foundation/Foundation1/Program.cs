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
        var video3 = new Video("The love of Christ for you", "Vivi", 132);
        
        // Add comments to the videos
        video1.AddComment(new Comment("Ukoh", "Great video!"));
        video1.AddComment(new Comment("UtahViewer", "Interesting content."));
        video1.AddComment(new Comment("Debbie", "You are right about the Love of Christ. "));
        video2.AddComment(new Comment("BYU456", "Well done."));
        video2.AddComment(new Comment("Joseph", "I have a strong testimony. "));
        video2.AddComment(new Comment("Pearl", "I love the Lord with all my heart. "));
        video3.AddComment(new Comment("Burton", "It encompassess all understanding. "));
        video3.AddComment(new Comment("User2024", "I love the words on the 24th seconds. "));
        video3.AddComment(new Comment("Laura", "I love the Church of Jesus Christ. "));

        
        // Display video details
        var videos = new List<Video> { video1, video2, video3 };
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}