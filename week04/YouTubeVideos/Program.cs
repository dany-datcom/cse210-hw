using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create the list of videos
        List<Video> videos = new List<Video>();

        // Video 1
        Video v1 = new Video("Learn JavaScript in 10 Minutes", "TechChannel", 600);
        v1.AddComment(new Comment("Anna", "Great summary!"));
        v1.AddComment(new Comment("Luis", "Very easy to understand."));
        v1.AddComment(new Comment("Peter", "Please make a video about async."));

        // Video 2
        Video v2 = new Video("How to Configure a Ubiquiti Network", "NetMaster", 900);
        v2.AddComment(new Comment("Carlos", "Exactly what I needed."));
        v2.AddComment(new Comment("Martha", "Does this work with the XG model?"));
        v2.AddComment(new Comment("George", "Thanks for the clear explanation."));

        // Video 3
        Video v3 = new Video("Strength Training Routine", "FitnessPro", 750);
        v3.AddComment(new Comment("Sofia", "Tried it and I loved it!"));
        v3.AddComment(new Comment("Leo", "Can you make a back workout?"));
        v3.AddComment(new Comment("Rachel", "Thanks for sharing!"));

        // Add videos to list
        videos.Add(v1);
        videos.Add(v2);
        videos.Add(v3);

        // Display all videos
        foreach (Video video in videos)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment c in video.GetComments())
            {
                Console.WriteLine($" - {c.Name}: {c.Text}");
            }
        }
    }
}