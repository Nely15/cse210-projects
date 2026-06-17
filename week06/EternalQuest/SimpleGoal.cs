public class SimpleGoal : Goal
{

    private bool _isComplete;

    //Constructor used when creating new goals
    public SimpleGoal(string name, string description, int points)
    : base(name, description, points)

    {

        _isComplete = false;

    }

    //Constructor used when loading from file
    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)

    {

        _isComplete = isComplete;

    }
    
    public override int RecordEvent()

    {

        if (_isComplete) return 0;

        _isComplete = true;
        return _points;

    }

    public override string GetStatusString()

    {

        return _isComplete ? "[X]" : "[ ]";

    }

    public override string GetStringRepresentation()

    {

        return $"SimpleGoal:{_name},{_description},{_points},{_isComplete}";

    }

}