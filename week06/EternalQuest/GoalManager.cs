using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager

{

    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()

    {

        bool running = true;

        while (running)

        {

            Console.WriteLine("\n===== * Eternal Quest * =====");
            Console.WriteLine($"Score: {_score}");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Load");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Choose: ");

            string choice = Console.ReadLine();

            switch (choice)

            {

                case "1": CreateGoal(); break;
                case "2": ShowGoals(); break;
                case "3": RecordEvent(); break;
                case "4": Save(); break;
                case "5": Load(); break;
                case "6": running = false; break;

            }

        }

    }

    private void CreateGoal()

    {

        Console.WriteLine("\nChoose type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2, Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")

        {

            _goals.Add(new SimpleGoal(name, desc, points));

        }

        else if (type == "2")

        {

            _goals.Add(new EternalGoal(name, desc, points));

        }

        else if (type == "3")

        {

            Console.WriteLine("Target times:");
            int target = int.Parse(Console.ReadLine());

            Console.WriteLine("Bonus points:");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));

        }

        Console.WriteLine("Goal created!");

    }

    private void ShowGoals()

    {
        Console.WriteLine("\n Your Goals:");
        for (int i = 0; i < _goals.Count; i++)

        {

            Console.WriteLine($"{i + 1}. {_goals[i].GetStatusString()} {_goals[i].GetName()}");

        }

    }

    private void RecordEvent()

    {

        ShowGoals();
        Console.Write("Which goal did you complete? ");

        int index = int.Parse(Console.ReadLine()) - 1;

        int points = _goals[index].RecordEvent();
        _score += points;

        Console.WriteLine($" You earned {points} points!");
        ShowLevel();

    }

    private void ShowLevel()

    {

        if (_score < 500)
            Console.WriteLine("Level: Beginner");

        else if (_score < 1500)
            Console.WriteLine("Level: Intermediate");

        else
            Console.WriteLine("Level: Master");

    }

    private void Save()

    {

        using (StreamWriter file = new StreamWriter("goals.txt"))

        {

            file.WriteLine(_score);

            foreach (Goal g in _goals)

            {

                file.WriteLine(g.GetStringRepresentation());

            }

        }

        Console.WriteLine("Saved!");

    }
    
    private void Load()

    {

        string[] lines = File.ReadAllLines("goals.txt");

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)

        {

            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string data = parts[1];
            string[] f = data.Split(",");

            if (type == "SimpleGoal")
                _goals.Add(new SimpleGoal(f[0], f[1], int.Parse(f[2])));

            else if (type == "EternalGoal")
                _goals.Add(new EternalGoal(f[0], f[1], int.Parse(f[2])));

            else if (type == "ChecklistGoal")
                _goals.Add(new ChecklistGoal(f[0], f[1], int.Parse(f[2]), int.Parse(f[4]), int.Parse(f[5])));

        }

        Console.WriteLine("Loaded!");
        
    }

}