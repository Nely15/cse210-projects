using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{

    private List<string> _prompts = new List<string>
    {

        "Who are people you appreciate?",
        "What are your personal strengths?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "What are some things you are grateful for?",

    };

    private static List<string> _unusedPromts = new List<string>();

    private Random _random = new Random();

    public ListingActivity()
    {

        _name = "Listing Activity";
        _description = "This activity helps you reflect on the good things in your life by having you list as many positive things that you can in a certain area.";

        //Fill prompt list when empty
        if (_unusedPromts.Count == 0)
        {

            _unusedPromts = new List<string>(_prompts);

        }

    }

    
    private string GetRandomPrompt()
    {

        int index = _random.Next(_unusedPromts.Count);

        string prompt = _unusedPromts[index];

        _unusedPromts.RemoveAt(index);

        //Refill after all prompts have been used
        if (_unusedPromts.Count == 0)
        {

            _unusedPromts = new List<string>(_prompts);

        }

        return prompt;

    }

    public void Run()
    {

        Start();

        Console.WriteLine();
        Console.WriteLine("Prompt:");
        Console.WriteLine(GetRandomPrompt());

        Console.WriteLine();
        Console.WriteLine("You may begin in...");
        ShowCountdown(5);

        Console.WriteLine();

        List<string> items = new List<string>();

        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {

            Console.Write("> ");

            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {

                items.Add(input);

            }

        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items.");

        LogActivity.ListingCount++;
        LogActivity.ListingSeconds += _duration;

        End();

    }
    
}