// Exceeding Requirements: I have added the feature of saving the goals to a json format, making it possible to use more characters in names and descriptions, this would not be possible with the format that was used in the demonstration video.

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}