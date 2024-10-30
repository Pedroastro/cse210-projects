using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(DateTime.Parse("2024-10-29"), 30, 4.8),
            new Cycling(DateTime.Parse("2024-10-30"), 45, 20.0),
            new Swimming(DateTime.Parse("2024-10-31"), 30, 30)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}