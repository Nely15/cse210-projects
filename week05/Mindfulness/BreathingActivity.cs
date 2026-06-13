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
            Console.Write("Breathe in... ");
            ShowCountdown(3);
            elapsed += 3;

            Console.WriteLine();
            Console.Write("Breathe out... ");
            ShowCountdown(3);
            elapsed += 3;

        }

        LogActivity.BreathingCount++;
        LogActivity.BreathingSeconds += _duration;

        End();

    }
    
}