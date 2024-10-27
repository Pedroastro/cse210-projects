public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _prompts = new List<string>{
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get Ready...");
        ShowSpinner(6);
        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt (type done to stop early):");
        Console.WriteLine($"  --- {GetRandomPrompt()} ---  ");
        Console.Write("You may begin in: ");
        ShowCountDown(6);
        Console.WriteLine();
        List<string> userList = GetListFromUser();
        _count = userList.Count;
        Console.WriteLine($"You listed {_count} items!");
        Console.WriteLine();
        DisplayEndingMessage();
    }

    public string GetRandomPrompt() 
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public List<string> GetListFromUser()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        List<string> userInputs = new List<string>();
        string userInput = "";
        while(DateTime.Now < endTime && userInput != "done")
        {
            Console.Write("> ");
            userInput = Console.ReadLine();
            userInputs.Add(userInput);
        }
        return userInputs;
    }
}
