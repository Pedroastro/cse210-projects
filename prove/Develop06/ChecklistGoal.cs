using System.Text.Json;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, string points, int target, int bonus) 
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override bool IsCompleted()
    {
        if (_amountCompleted >= _target)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string GetDetailsString()
    {
        if (IsCompleted())
        {
            return $"[X] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/3";
        }
        else
        {
            return $"[ ] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/3";
        }
    }

    public override string GetStringRepresentation()
    {
        return JsonSerializer.Serialize(new
        {
            Type = GetType().Name,
            Name = _shortName,
            Description = _description,
            Points = _points,
            AmountCompleted = _amountCompleted,
            Target = _target,
            Bonus = _bonus
        });
    }

    public int GetBonus()
    {
        return _bonus;
    }
}