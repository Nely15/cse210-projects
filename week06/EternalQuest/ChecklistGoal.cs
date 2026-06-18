using System;
public class ChecklistGoal : Goal

{

    private int _completed;
    private int _target;
    private int _bonus;
    private bool _isComplete;

    //creativity feature
    private int _level;
    private int[] _milestones = { 30, 90, 180, 365 };

    private int _streak;
    private DateTime _lastCompleted;
    private int _frequencyDays;

    private int _penalty;

    //For creating new goals
    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)

    {

        _completed = 0;
        _target = target;
        _bonus = bonus;
        _isComplete = false;

        _level = 0;
        _lastCompleted = DateTime.MinValue;
        _streak = 0;
        _frequencyDays = 1;
        _penalty = 5;

    }

    //Loading Constructor
    public ChecklistGoal(string name, string description, int points,
        int completed, int target, int bonus, bool isComplete, int level, int streak, DateTime lastCompleted)
        : base(name, description, points)
    
    {

        _completed = completed;
        _target = target;
        _bonus = bonus;
        _isComplete = isComplete;

        _level = level;
        _streak = streak;
        _lastCompleted = lastCompleted;

        _frequencyDays = 1;
        _penalty = 5;

    }

    public override int RecordEvent()

    {

        if (_isComplete) 
            return 0;

        int total = _points;

        //Detects broken streak
        if (_lastCompleted != DateTime.MinValue)

        {

            int daysMissed = (DateTime.Now - _lastCompleted).Days;

            if (daysMissed > _frequencyDays)

            {

                int penalty = (daysMissed - _frequencyDays) * _penalty;

                Console.WriteLine($"Streak broken! Lost {penalty} points.");

                total -= penalty;
                _streak = 0;

            }

        }

        _lastCompleted = DateTime.Now;
        _streak++;

        _completed++;

        //level system
        if (_completed >= _target)

        {

            total += _bonus;

            if (_level < _milestones.Length - 1)

            {

                _level++;
                _completed = 0;
                _target = _milestones[_level];

                Console.WriteLine("Goal leveled up!");
                Console.WriteLine($"Next Challenge: {_target} completions.");

            }

            else

            {

                _isComplete = true;
                Console.WriteLine("Maximum level reached!");

            }

        }

        return Math.Max(0, total);

    }


    public override string GetStatusString()

    {

        return _isComplete
            ? $"[x] {_completed}/{_target}"
            : $"[ ] {_completed}/{_target}";

    }

    public override string GetStringRepresentation()

    {

        return $"ChecklistGoal:{_name},{_description},{_points},{_completed},{_target},{_bonus},{_isComplete},{_level},{_streak},{_lastCompleted.ToString("o")}";

    }

    public override string GetDetailString()

    {

        return $"{GetStatusString()} {_name} ({_description}) -- Level {_level + 1} | Streak: {_streak} | Progress: {_completed}/{_target}";

    }

    public override int ApplyPenalty()
    {

        return _penalty;

    }

}