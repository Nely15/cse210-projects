using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        int userNum = -1; 

        while (userNum !=0)
        {

            Console.Write("Enter number: ");
            userNum = int.Parse(Console.ReadLine());

            if (userNum != 0)
            {
                numbers.Add(userNum);
            }

        }

        int sum = 0;

        foreach (int num in numbers)
        {
            sum = sum + num;
        }

        double average = (double)sum / numbers.Count;


        int largestNum = numbers[0];

        foreach (int num in numbers)
        {
            if (num > largestNum)
            {
                largestNum = num;
            }
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNum}");
    }
}