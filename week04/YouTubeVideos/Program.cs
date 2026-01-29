using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("How to Learn C# Fast", "CodeMaster", 540);
        video1.AddComment(new Comment("Simba", "This helped me a lot!"));
        video1.AddComment(new Comment("Ronald", "Great explanation, thank you."));
        video1.AddComment(new Comment("Tariro", "Can you make one for classes next?"));

        Video video2 = new Video("Top 5 Study Tips", "StudentSuccess", 420);
        video2.AddComment(new Comment("Clive", "I needed this today."));
        video2.AddComment(new Comment("Nyasha", "Tip #3 is my favorite."));
        video2.AddComment(new Comment("Blessing", "This is motivating!"));

        Video video3 = new Video("Build a Simple Game in C#", "DevHub", 900);
        video3.AddComment(new Comment("Kuda", "This was so fun to follow."));
        video3.AddComment(new Comment("Simbarashe", "I finally understand loops now."));
        video3.AddComment(new Comment("Rumbi", "Please do more projects like this."));

        // Put videos into a list
        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}
