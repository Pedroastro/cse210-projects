public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will guide you through slow, deep breathing to help you relax. Clear your mind and focus on each breath.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get Ready...");
        ShowSpinner(6);
        Console.WriteLine();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while(DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowCountDown(4);
            Console.WriteLine();
            Console.Write("Now breathe out...");
            ShowCountDown(6);
            Console.WriteLine();
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }
}
