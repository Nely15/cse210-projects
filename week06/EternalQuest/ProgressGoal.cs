using System;

public class ProgressGoal : Goal
{

    private int _current;
    private int _target;
    private bool _isComplete;

    public ProgressGoal(string name, string description, int points, int target)
        : base(name, description, points)

    {
        _current = 0;
        _target = target;
        _isComplete = false;

    }

    public override int RecordEvent()

    {

        if (_isComplete)
            return 0;

        _current++;

        if (_current >= _target)
            _isComplete = true;

        return _points;

    }

    public override string GetStatusString()

    {

        return _isComplete
        ? $"[X] {_current}/{_target}"
        : $"[ ] {_current}/{_target}";

    }

    public override string GetStringRepresentation()

    {

        return $"ProgressGoal:{_name},{_description},{_points},{_current},{_target},{_isComplete}";

    }

    public override int ApplyPenalty()
    
    {
        return 0;
    }

}