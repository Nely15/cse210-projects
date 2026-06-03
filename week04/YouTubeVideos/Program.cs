using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)

    {

        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Bake Cookies", "Elimar", 420);

        video1.AddComment(new Comment("Ervin", "Great recipe!"));
        video1.AddComment(new Comment("Andrea", "I will try this tonight."));
        video1.AddComment(new Comment("Marcus", "Looks delicious"));

        videos.Add(video1);


        Video video2 = new Video("Traveling to Japan", "World Explorer", 750);

        video2.AddComment(new Comment("Samantha", "Japan is on my bucket list."));
        video2.AddComment(new Comment("Corey", "Beautiful places."));
        video2.AddComment(new Comment("Matthew", "Great travel tips."));

        videos.Add(video2);


        Video video3 = new Video("Learning Russian for Beginners", "Language Hub", 1800);

        video3.AddComment(new Comment("Eva", "This lesson was easy to follow."));
        video3.AddComment(new Comment("Marvin", "I learned a lot of new words."));
        video3.AddComment(new Comment("Jacob", "Great explanation of pronunciation."));

        videos.Add(video3);


        Video video4 = new Video("10 Minute Home Workout", "Fit Life", 650);

        video4.AddComment(new Comment("Erin", "Perfect workout for busy days."));
        video4.AddComment(new Comment("Tyler", "I really felt the burn."));
        video4.AddComment(new Comment("Gabriela", "Looking forward to more videos."));

        videos.Add(video4);

        foreach (Video video in videos)

        {
            
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())

            {

                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetCommentText()}");

            }

            Console.WriteLine();
            
        }
    }
}