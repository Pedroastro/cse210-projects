using System.Text.Json;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsCompleted()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return JsonSerializer.Serialize(new
        {
            Type = GetType().Name,
            Name = _shortName,
            Description = _description,
            Points = _points,
            IsComplete = _isComplete
        });
    }
}