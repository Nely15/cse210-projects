using System;

public class NegativeGoal : Goal
{

    public NegativeGoal(string name, string description, int points)
        : base(name, description, points)

    { }

    public override int RecordEvent()

    {

        return -_points;

    }

    public override string GetStatusString()

    {

        return "[!]";

    }

    public override string GetStringRepresentation()

    {

        return $"NegativeGoal:{_name},{_description},{_points}";

    }
    
}