using System.Text.Json;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        Console.WriteLine("\n--- Eternal Quest Program ---");
        bool running = true;
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine($"Current Score: {_score}");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Exit");
            Console.Write("\nSelect a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine();
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine();
    }

    public void ListGoalNames()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Types of Goals:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        
        string type = Console.ReadLine();
        
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();

        Goal newGoal;
        switch (type)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        _goals.Add(newGoal);
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("\nWhich goal did you accomplish? (Enter number): ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
        {
            Goal goal = _goals[index - 1];
            goal.RecordEvent();
            int points = goal.GetPoints();
            _score += points;
            
            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsCompleted())
            {
                int bonus = ((ChecklistGoal)goal).GetBonus();
                _score += bonus;
                Console.WriteLine($"Congratulations! You have earned {points + bonus} points!");
            }
            else
            {
                Console.WriteLine($"Congratulations! You have earned {points} points!");
            }
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();
        if (!File.Exists(fileName))
        {
            Console.WriteLine("No file for saving goals found.");
            return;
        }

        var saveData = new
        {
            Score = _score,
            Goals = _goals.Select(g => g.GetStringRepresentation()).ToList()
        };

        string json = JsonSerializer.Serialize(saveData);
        File.WriteAllText(fileName, json);
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();
        if (!File.Exists(fileName))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        string json = File.ReadAllText(fileName);
        var saveData = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);
        
        _score = saveData["Score"].GetInt32();
        var goalsArray = saveData["Goals"].EnumerateArray();
        
        _goals.Clear();
        foreach (var goalJson in goalsArray)
        {
            var goalData = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(goalJson.GetString());
            string type = goalData["Type"].GetString();
            string name = goalData["Name"].GetString();
            string description = goalData["Description"].GetString();
            string points = goalData["Points"].GetString();

            Goal goal;
            switch (type)
            {
                case "SimpleGoal":
                    goal = new SimpleGoal(name, description, points);
                    if (goalData["IsComplete"].GetBoolean())
                        goal.RecordEvent();
                    break;
                case "EternalGoal":
                    goal = new EternalGoal(name, description, points);
                    break;
                case "ChecklistGoal":
                    int target = goalData["Target"].GetInt32();
                    int bonus = goalData["Bonus"].GetInt32();
                    goal = new ChecklistGoal(name, description, points, target, bonus);
                    int amountCompleted = goalData["AmountCompleted"].GetInt32();
                    for (int i = 0; i < amountCompleted; i++)
                        goal.RecordEvent();
                    break;
                default:
                    continue;
            }
            _goals.Add(goal);
        }
        Console.WriteLine("Goals loaded successfully!");
    }
}