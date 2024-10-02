using System;

class Program
{
    static void Main(string[] args)
    {
        // 1
        Fraction one = new Fraction();
        Console.WriteLine(one.GetFractionString());
        Console.WriteLine(one.GetDecimalValue());

        // 5
        Fraction five = new Fraction(5);
        Console.WriteLine(five.GetFractionString());
        Console.WriteLine(five.GetDecimalValue());

        // 3/4
        Fraction threeOverFour = new Fraction(3,4);
        Console.WriteLine(threeOverFour.GetFractionString());
        Console.WriteLine(threeOverFour.GetDecimalValue());

        // 1/3
        Fraction oneThird = new Fraction(1,3);
        Console.WriteLine(oneThird.GetFractionString());
        Console.WriteLine(oneThird.GetDecimalValue());
    }
}