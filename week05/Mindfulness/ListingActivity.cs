using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{

    private List<string> _prompts = new List<string>
    {

        "List people you appreciate.",
        "List your personal strengths.",
        "List people you helped recently.",
        "List things you are grateful for.",

    };

    public ListingActivity()
    {

        _name = "Listing Activity";
        _description = "This activity helps you list positive things in your life.";

    }

    public void Run()
    {

        Start();

        Random rand = new Random();

        Console.WriteLine();
        Console.WriteLine("Prompt:");
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);

        Console.WriteLine();
        Console.WriteLine("You may begin in...");
        ShowCountdown(5);

        Console.WriteLine();

        List<string> items = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {

            Console.WriteLine("> ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {

                items.Add(input);

            }

        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items.");

        End();

    }
    
}