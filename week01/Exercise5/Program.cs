using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string name = UserName();
        int number = UserNumber();

        int squared = SquaredNumber(number);

        DisplayResult(name, squared);
    }

    static void DisplayWelcome() => Console.WriteLine("Welcome to the Program!");

    static string UserName()
    {
        Console.Write("What is your name?: ");
        string name = Console.ReadLine();

        return name;

    }

    static int UserNumber()
    {
        Console.Write("What is your favorite number?: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static int SquaredNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int squaredNumber) => Console.WriteLine($"{name}, the square of your number is {squaredNumber}");

}