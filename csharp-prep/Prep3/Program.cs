using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);

        int userNumber;
        do
        {
            Console.Write("What is your guess?");
            string userInput = Console.ReadLine();
            userNumber = int.Parse(userInput);
            
            if (userNumber < number)
            {
                Console.WriteLine("Higher");
            }
            else if (userNumber > number)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        } while (userNumber != number);
    }
}