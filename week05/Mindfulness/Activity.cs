using System;
using System.Threading;

public class Activity
{

    protected string _name;
    protected string _description;
    protected int _duration;

    public void Start()
    {

        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.WriteLine("How many seconds would you like to do this activity? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);

    }

    public void End()
    {

        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(2);

        Console.WriteLine($"You completed {_name} for {_duration} seconds.");
        ShowSpinner(3);

    }

    protected void ShowSpinner(int seconds)
    {

        string[] spinner = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < end)
        {

            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(200);
            Console.Write("b");
            i++;

        }

    }

    protected void ShowCountdown(int seconds)
    {

        for (int i = seconds; i > 0; i--)
        {

            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");

        }
        
    }

}