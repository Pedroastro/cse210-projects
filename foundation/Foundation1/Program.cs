using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Comment video1Comment1 = new Comment("TechWiz123", "This video is perfect for a quick refresh! Thanks for simplifying the concepts.");
        Comment video1Comment2 = new Comment("PyDev_89", "Loved the explanations on list comprehensions. I finally get it!");
        Comment video1Comment3 = new Comment("CodeGirl", "Wish this had more advanced topics, but great for beginners.");
        Comment video1Comment4 = new Comment("GeekyDude12", "Can't believe how much I learned in just 10 minutes. Subscribed!");
        List<Comment> video1Comments = new List<Comment>();
        video1Comments.Add(video1Comment1);
        video1Comments.Add(video1Comment2);
        video1Comments.Add(video1Comment3);
        video1Comments.Add(video1Comment4);
        Video video1 = new Video("Mastering Python in 10 Minutes", "CodeSavvy", 600, video1Comments);
        videos.Add(video1);

        Comment video2Comment1 = new Comment("SweetTooth", "Tried this recipe today, and it came out fantastic! Thank you!");
        Comment video2Comment2 = new Comment("BakeBoss99", "I followed every step, but my cake didn't rise. What did I do wrong?");
        Comment video2Comment3 = new Comment("ChocoLover88", "This cake is a dream! Made it for my family, and they loved it!");
        Comment video2Comment4 = new Comment("FlourPower", "Great video, but can you make a gluten-free version?");
        List<Comment> video2Comments = new List<Comment>();
        video2Comments.Add(video2Comment1);
        video2Comments.Add(video2Comment2);
        video2Comments.Add(video2Comment3);
        video2Comments.Add(video2Comment4);
        Video video2 = new Video("How to Bake the Perfect Chocolate Cake", "TheBakingGuru", 1080, video2Comments);
        videos.Add(video2);

        Comment video3Comment1 = new Comment("NamasteNancy", "I feel so much better after following this routine. Thank you!");
        Comment video3Comment2 = new Comment("CalmVibes", "Perfect for winding down after a long day at work. Love it!");
        Comment video3Comment3 = new Comment("StretchySam", "Some of these poses were harder than expected, but great video!");
        Comment video3Comment4 = new Comment("MindfulMandy", "I've been doing this every day for a week now. Total game changer!");
        List<Comment> video3Comments = new List<Comment>();
        video3Comments.Add(video3Comment1);
        video3Comments.Add(video3Comment2);
        video3Comments.Add(video3Comment3);
        video3Comments.Add(video3Comment4);
        Video video3 = new Video("Yoga for Stress Relief: 20-Minute Beginner Routine", "ZenLife", 1200, video3Comments);
        videos.Add(video3);

        Comment video4Comment1 = new Comment("GlobeTrotter", "Adding these places to my bucket list! Thanks for the inspiration.");
        Comment video4Comment2 = new Comment("JetSetJen", "I've been to 3 of these spots, and they are indeed incredible!");
        Comment video4Comment3 = new Comment("TravelBug", "How come Bali didn't make the list? It's one of my favorites!");
        Comment video4Comment4 = new Comment("AdventureAaron", "Great video! Any tips for budget-friendly trips to these destinations?");
        List<Comment> video4Comments = new List<Comment>();
        video4Comments.Add(video4Comment1);
        video4Comments.Add(video4Comment2);
        video4Comments.Add(video4Comment3);
        video4Comments.Add(video4Comment4);
        Video video4 = new Video("Top 10 Travel Destinations for 2025", "Wanderlust World", 900, video4Comments);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.Write(video.GetVideoInformation());
            Console.WriteLine($"Number of Comments: {video.CommentsCount()}");
            Console.Write(video.GetCommentsInformation());
            Console.WriteLine();
        }
    }
}