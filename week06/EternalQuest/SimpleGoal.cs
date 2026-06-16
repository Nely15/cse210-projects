public class SimpleGoal : Goal
{

    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
    : base(name, description, points)

    {

        _isComplete = false;

    }

    public override int RecordEvent()

    {

        if (_isComplete) return 0;

        _isComplete = true;
        return _points;

    }

    public override string GetStatusString()

    {

        return _isComplete ? "[X]" : "[]";

    }

    public override string GetStringRepresentation()

    {

        return $"SimpleGoal:{_name},{_description}, {_points},{_isComplete}";

    }
    
}