using System;

public class BreathingActivity : Activity
{

    public BreathingActivity()
    {

        _name = "Breathing Activity";
        _description = "This activity helps you relax by guiding slow breathing in and out.";

    }

    public void Run()
    {

        Start();

        int elapsed = 0;

        while (elapsed < _duration)
        {

            Console.WriteLine();
            Console.Write("Breath in... ");
            ShowCountdown(4);
            elapsed += 4;

            Console.WriteLine();
            Console.Write("Breath out... ");
            ShowCountdown(4);
            elapsed += 4;

        }

        End();

    }
    
}