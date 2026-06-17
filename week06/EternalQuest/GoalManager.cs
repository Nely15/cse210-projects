using System;
using System.Globalization;
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

            Console.WriteLine("\n======== * Eternal Quest * ========");
            Console.WriteLine($"Score: {_score}");

            Console.WriteLine("\n===== * Goal Types Available * =====");
            Console.WriteLine("Simple Goal");
            Console.WriteLine("Eternal Goal");
            Console.WriteLine("Checklist Goal");
            Console.WriteLine("Progress Goal");
            Console.WriteLine("Negative Goal");

            Console.WriteLine("\n====================================");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. View Current Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Record Missed Goal"); 
            Console.WriteLine("5. Save");
            Console.WriteLine("6. Load");
            Console.WriteLine("7. Exit");
            Console.WriteLine("\n====================================");
            Console.WriteLine("Choose: ");

            string choice = Console.ReadLine();

            switch (choice)

            {

                case "1": CreateGoal(); break;
                case "2": ShowGoals(); break;
                case "3": RecordEvent(); break;
                case "4": RecordMissedGoal(); break;
                case "5": Save(); break;
                case "6": Load(); break;
                case "7": running = false; break;

                default:
                    Console.WriteLine("Please choose a valid option.");
                    break;

            }

        }

    }

    private void CreateGoal()

    {

        Console.WriteLine("\nChoose type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal");
        Console.WriteLine("5. Progress Goal");

        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points;
        while (!int.TryParse(Console.ReadLine(), out points))

        {

            Console.Write("Please enter a valid number: ");

        }

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
            int target;

            while (!int.TryParse(Console.ReadLine(), out target))

            {

                Console.Write("Please enter a valid number: ");

            }

            Console.WriteLine("Bonus points:");
            int bonus;
            while (!int.TryParse(Console.ReadLine(), out bonus))

            {

                Console.Write("Please enter a valid number: ");

            }


            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));

        }

        else if (type == "4")

        {

            _goals.Add(new NegativeGoal(name, desc, points));

        }

        else if (type == "5")

        {

            Console.Write("Target times: ");

            int target;
            while (!int.TryParse(Console.ReadLine(), out target))

            {

                Console.Write("Please enter a valid number: ");

            }

            _goals.Add(new ProgressGoal(name, desc, points, target));

        }

    }
    private void ShowGoals()

    {
        Console.WriteLine("\n Your Current Goals:");

        if (_goals.Count == 0)

        {

            Console.WriteLine("You don't have any goals yet.");
            return;

        }

        for (int i = 0; i < _goals.Count; i++)

        {

            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailString()}");

        }

    }
    

    private void RecordEvent()
        
    {

        ShowGoals();

        if (_goals.Count == 0)

        {

            return;

        }

        Console.Write("Which goal did you complete? ");

        int index;

        while (!int.TryParse(Console.ReadLine(), out index))

        {

            Console.Write("Please enter a valid number: ");

        }

        index--;

        if (index < 0 || index >= _goals.Count)

        {

            Console.WriteLine("Invalid selection. ");
            return;

        }
        
        int points = _goals[index].RecordEvent();
        _score += points;

        CheckAchievements();

        if (_score < 0)

        {

            _score = 0;

        }

        if (points >= 0)

        {

            Console.WriteLine($"You earned {points} points!");

        }

        else

        {

            Console.WriteLine($" You lost {-points} points!");
            
        }

        
        

    }

    private void RecordMissedGoal()

    {

        ShowGoals();

        if (_goals.Count == 0)

        {

            return;
            
        }

        Console.Write("Which goal did you miss? ");

        int index;

        while (!int.TryParse(Console.ReadLine(), out index))

        {

            Console.Write("Please enter a valid number: ");

        }

        index--;

        if (index < 0 || index >= _goals.Count)

        {

            Console.WriteLine("Invalid selection. ");
            return;

        }

        int penalty = _goals[index].ApplyPenalty();

        _score -= penalty;

        if (_score < 0)

        {

            _score = 0;

        }

        Console.WriteLine($" You lost {penalty} points.");

    }
    private void ShowLevel()

    {

        if (_score < 500)
            Console.WriteLine("Level 1: Beginner");

        else if (_score < 1500)
            Console.WriteLine("Level 2: Intermediate");

        else if (_score < 3000)
            Console.WriteLine("Level 3: Champion");

        else
            Console.WriteLine("Level 4: Master");

    }

    private void CheckAchievements()

    {

        if (_score >= 1000)
        
            Console.WriteLine("Achievements unlocked: Rising Star!");

        if (_score >= 5000)

            Console.WriteLine("Achievements unlocked: Goal Master!");

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

        if (!File.Exists("goals.txt"))

        {

            Console.WriteLine("No save file found.");
            return;

        }

        string[] lines = File.ReadAllLines("goals.txt");

        if (lines.Length == 0)

        {

            Console.WriteLine("Save file is empty.");
            return;

        }

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)

        {

            string[] parts = lines[i].Split(':', 2);
            string type = parts[0];
            string data = parts[1];
            string[] f = data.Split(",");

            if (type == "SimpleGoal")
                _goals.Add(new SimpleGoal(f[0], f[1], int.Parse(f[2]), bool.Parse(f[3])));

            else if (type == "EternalGoal")
                _goals.Add(new EternalGoal(f[0], f[1], int.Parse(f[2])));

            else if (type == "ChecklistGoal")
                _goals.Add(new ChecklistGoal(
                    f[0], f[1], int.Parse(f[2]), int.Parse(f[3]), int.Parse(f[4]), int.Parse(f[5]), bool.Parse(f[6]), int.Parse(f[7]), int.Parse(f[8]), DateTime.Parse(f[9], null, DateTimeStyles.RoundtripKind)));

            else if (type == "NegativeGoal")

            {

                _goals.Add(new NegativeGoal(f[0], f[1], int.Parse(f[2])));

            }

        }

        Console.WriteLine("Loaded!");
        
    }

}