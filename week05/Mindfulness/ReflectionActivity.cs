using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{

    private List<string> _prompt = new List<string>
    {

        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you were proud of yourself.",
        "Think of a time when you showed strength."

    };

    private List<string> _questions = new List<string>
    {

        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you feel at that time?",
        "How did you feel when it was complete?",
        "What did you learn about yourself?",
        "What made this time different than other times when you were not as successful?"

    };

    public ReflectionActivity()
    {

        _name = "Reflection Activity";
        _description = "This activity helps you reflect on menaningful experiences in your life.";

    }

    public void Run()
    {

        Start();

        Random rand = new Random();

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine(_prompt[rand.Next(_prompt.Count)]);
        ShowSpinner(3);

        int elapsed = 0;

        while (elapsed < _duration)
        {

            Console.WriteLine();
            Console.WriteLine(_questions[rand.Next(_questions.Count)]);
            ShowSpinner(4);
            elapsed += 4;

        }

        End();

    }

}