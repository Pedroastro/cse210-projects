using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello there! Welcome to your journal!");
        Journal myJournal = new Journal();

        while (true)
        {
            Console.WriteLine("What would you like to do? (Please select one of the options)");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("6. Write with my prompt");
            Console.Write("Which of these would you like to do? ");
            string userInput = Console.ReadLine();

            if (userInput == "1" || userInput.ToLower() == "write")
            {
                DateTime theCurrentTime = DateTime.Now;
                string date = theCurrentTime.ToShortDateString();

                PromptGenerator promptGenerator = new PromptGenerator();
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine(prompt);
                string entryText = Console.ReadLine();

                Entry entry = new Entry();
                entry._date = date;
                entry._promptText = prompt;
                entry._entryText = entryText;

                myJournal.AddEntry(entry);
            }
            else if (userInput == "2" || userInput.ToLower() == "display")
            {
                myJournal.DisplayAll();
            }
            else if (userInput == "3" || userInput.ToLower() == "load")
            {
                Console.WriteLine("What is the filename?");
                string file = Console.ReadLine();
                myJournal = new Journal();
                myJournal.LoadFromFile(file);
            }
            else if (userInput == "4" || userInput.ToLower() == "save")
            {
                Console.WriteLine("What is the filename?");
                string file = Console.ReadLine();
                myJournal.SaveToFile(file);
            }
            else if (userInput == "5" || userInput.ToLower() == "quit")
            {
                Environment.Exit(0);
            }
            else if (userInput == "6" || userInput.ToLower() == "write with my prompt")
            {
                DateTime theCurrentTime = DateTime.Now;
                string date = theCurrentTime.ToShortDateString();

                Console.Write("Write your prompt: ");
                string prompt = Console.ReadLine();

                Console.WriteLine(prompt);
                string entryText = Console.ReadLine();

                Entry entry = new Entry();
                entry._date = date;
                entry._promptText = prompt;
                entry._entryText = entryText;

                myJournal.AddEntry(entry);
            }
            else
            {
                Console.WriteLine("Option not valid.");
            }
        }
    }
}