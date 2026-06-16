public class ChecklistGoal : Goal

{

    private int _completed;
    private int _target;
    private int _bonus;
    private bool _isComplete;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)

    {

        _target = target;
        _bonus = bonus;
        _completed = 0;
        _isComplete = false;

    }

    public override int RecordEvent()

    {

        if (_isComplete) return 0;

        _completed++;
        int total = _points;

        if (_completed >= _target)

        {

            _isComplete = true;
            total += _bonus;

        }

        return total;

    }

    public override string GetStatusString()

    {

        return _isComplete
            ? $"[x] {_completed}/{_target}"
            : $"[ ] {_completed}/{_target}";

    }

    public override string GetStringRepresentation()

    {

        return $"ChecklistGoal:{_name},{_description},{_points},{_completed},{_target},{_bonus},{_isComplete}";

    }

}