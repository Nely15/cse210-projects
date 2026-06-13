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

    private static List<string> _unusedPrompts = new List<string>();

    private Random _random = new Random();

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
        _description = "This activity will help you reflect on times  in your life when you have shown strength and resilience. Reflecting on these meaningful experiences in your life will help you recognize the power you have and how you can use it in other aspects of your life.";

        if (_unusedPrompts.Count == 0)
        {

            _unusedPrompts = new List<string>(_prompt);
        }

    }

    private string GetRandomPrompt()
    {

        int index = _random.Next(_unusedPrompts.Count);

        string chosen = _unusedPrompts[index];

        _unusedPrompts.RemoveAt(index);
        
        if (_unusedPrompts.Count == 0)
        {

            _unusedPrompts = new List<string>(_prompt);

        }

        return chosen;

    }


    public void Run()
    {

        Start();

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine(GetRandomPrompt());
        ShowSpinner(3);

        List<string> availableQuestions = new List<string>(_questions);

        int questionCount = Math.Min(availableQuestions.Count, _duration / 6);

        if (questionCount < 1)
        {

            questionCount = 1;

        }

        int pauseTime = _duration / questionCount;

        for (int i = 0; i < questionCount; i++)
        {

            int index = _random.Next(availableQuestions.Count);

            string question = availableQuestions[index];

            availableQuestions.RemoveAt(index);

            Console.WriteLine();
            Console.WriteLine(question);

            ShowSpinner(pauseTime);

        }

        LogActivity.ReflectionCount++;
        LogActivity.ReflectionSeconds += _duration;

        End();

    }

}