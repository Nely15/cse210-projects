using System;

public abstract class Goal

{

    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)

    {

        _name = name;
        _description = description;
        _points = points;

    }

    public string GetName()

    {

        return _name;

    }

    public abstract int RecordEvent();
    public abstract string GetStatusString();
    public abstract string GetStringRepresentation();

    public virtual int ApplyPenalty()

    {

        return 5;

    }


    public virtual string GetDetailString()

    {

        return $"{GetStatusString()} {_name} ({_description})";

    }

}