using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;


public class GoalManager

{

    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    // Main Loop
    public void Start()

    {

        bool running = true;

        while (running)

        {

            DisplayHeader();
            DisplayMenu();

            string choice = Console.ReadLine();
            HandleMenuChoice(choice);

        }

    }

    //Menu Handler
    private void HandleMenuChoice(string choice)

    {

        switch (choice)

        {

            case "1": CreateGoal(); break;
            case "2": ShowGoals(); break;
            case "3": RecordEvent(); break;
            case "4": RecordMissedGoal(); break;
            case "5": Save(); break;
            case "6": Load(); break;
            case "7": Environment.Exit(0); break;

            default:
                Console.WriteLine("Please choose a valid option.");
                break;

        }

    }

    //UI Display
    private void DisplayHeader()

    {

        Console.WriteLine("\n======== * Eternal Quest * ========");
        Console.WriteLine($"Score: {_score}");

    }

    private void DisplayMenu()

    {

        Console.WriteLine("\n===== * Goal Types Available * =====");
        Console.WriteLine("Simple Goal");
        Console.WriteLine("Eternal Goal");
        Console.WriteLine("Checklist Goal");
    

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

    }

    //Create Goal
    private void CreateGoal()

    {

        Console.WriteLine("\nChoose type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        int points = GetInt("Points: ");

        if (type == "1")
            _goals.Add(new SimpleGoal(name, desc, points));

        else if (type == "2")
            _goals.Add(new EternalGoal(name, desc, points));

        else if (type == "3")

        {

            int target = GetInt("Target times: ");
            int bonus = GetInt("Bonus points: ");

            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));

        }

    }
    
    //Show Goals
    private void ShowGoals()

    {
        Console.WriteLine("\n====== Your Current Goals:======");

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
    
    //Record Event
    private void RecordEvent()
        
    {

        ShowGoals();

        if (_goals.Count == 0) return;

        int index = GetInt("Which goal did you complete? ") - 1;

        if (!IsValidIndex(index))

        {

            Console.WriteLine("Invalid selection. ");
            return;

        }
        
        int points = _goals[index].RecordEvent();
        _score += points;

        if (_score < 0) _score = 0;

        CheckAchievements();
        ShowLevel();

        if (points >= 0)

        {

            Console.WriteLine($"You earned {points} points!");

        }

        else

        {

            Console.WriteLine($" You lost {-points} points!");
            
        }

    }

    //Record Miss
    private void RecordMissedGoal()

    {

        ShowGoals();

        if (_goals.Count == 0)
            return;


        int index = GetInt("Which goal did you miss? ") - 1;

        if (!IsValidIndex(index))

        {

            Console.WriteLine("Invalid selection. ");
            return;

        }

        int penalty = _goals[index].ApplyPenalty();

        _score -= penalty;

        if (_score < 0)
            _score = 0;


        Console.WriteLine($" You lost {penalty} points.");

    }

    //Save & Load
    private void Save()

    {

        using (StreamWriter file = new StreamWriter("goals.txt"))

        {

            file.WriteLine(_score);

            foreach (Goal g in _goals)
                file.WriteLine(g.GetStringRepresentation());

        }

        Console.WriteLine("Saved!");

    }

    private void Load()

    {

        try
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
                string[] f = parts[1].Split(",");

                if (type == "SimpleGoal")

                {

                    _goals.Add(new SimpleGoal(f[0], f[1], int.Parse(f[2]), bool.Parse(f[3])));

                }

                else if (type == "EternalGoal")

                {

                    _goals.Add(new EternalGoal(f[0], f[1], int.Parse(f[2])));

                }

                else if (type == "ChecklistGoal")

                {
                    _goals.Add(new ChecklistGoal(
                        f[0], f[1], int.Parse(f[2]), int.Parse(f[3]), int.Parse(f[4]), int.Parse(f[5]), bool.Parse(f[6]), int.Parse(f[7]), int.Parse(f[8]), DateTime.Parse(f[9], null, DateTimeStyles.RoundtripKind)));

                }

            }

            Console.WriteLine("Loaded!");

        }

        catch (Exception)

        {

            Console.WriteLine("Error loading save file. The file may be corrupted.");

        }
        
    }
    //Helpers
    private int GetInt(string prompt)

    {

        Console.Write(prompt);

        int value;
        while (!int.TryParse(Console.ReadLine(), out value))

        {

            Console.Write("Invalid input. Try again: ");

        }

        return value;

    }

    private bool IsValidIndex(int index)

    {

        return index >= 0 && index < _goals.Count;

    }

    //Level & achievements
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



}