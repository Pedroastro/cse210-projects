using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment testAssignment = new Assignment("Pedro", "Math");
        Console.WriteLine(testAssignment.GetSummary());

        MathAssignment testMathAssignment = new MathAssignment("Pedro", "Math", "Section 1", "Problem 2");
        Console.WriteLine(testMathAssignment.GetSummary());
        Console.WriteLine(testMathAssignment.GetHomeworkList());

        WritingAssignment testWritingAssignment = new WritingAssignment("Pedro", "Writing", "My Novel");
        Console.WriteLine(testWritingAssignment.GetSummary());
        Console.WriteLine(testWritingAssignment.GetWritingInformation());
    }
}