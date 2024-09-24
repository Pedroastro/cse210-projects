using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbersList = new List<int>();
        int number = 1;
        float sum = 0;
        while (number != 0)
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            number = int.Parse(userInput);
            if (number != 0)
            {
                numbersList.Add(number);
                sum += number;
            }
        }
        float average = sum / numbersList.Count;

        int largestNumber = numbersList[0];
        foreach (int n in numbersList)
        {
            if (n > largestNumber)
            {
                largestNumber = n;
            }
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNumber}");
    }
}